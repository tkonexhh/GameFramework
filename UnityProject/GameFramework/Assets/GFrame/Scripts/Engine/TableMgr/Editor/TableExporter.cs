using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using LitJson;

namespace GFrame.UnityEditor
{

    public class TableExporter
    {
        //[MenuItem("Assets/GFrame/Table/Build TXT")]
        public static void BuildTxt()
        {

        }
        [MenuItem("Assets/GFrame/Table/Build C#")]
        public static void BuildCCode()
        {
            string dataFolderPath = ProjectPathConfig.externalTablePath;

            string[] allTableFiles = Directory.GetFiles(dataFolderPath, "*.xlsx", SearchOption.AllDirectories);
            if (allTableFiles == null || allTableFiles.Length <= 0)
            {
                Debug.LogError("#No Table Found in" + dataFolderPath);
                return;
            }
            for (int i = 0; i < allTableFiles.Length; i++)
            {
                EditorUtility.DisplayProgressBar("Hold on", "Processing", (float)(i + 1) / allTableFiles.Length);
                if (PathHelper.Path2Name(allTableFiles[i]).StartsWith("~"))
                {
                    continue;
                }
                ExcelUtility excel = new ExcelUtility(allTableFiles[i]);
                excel.WriteDataFile(allTableFiles[i]);
            }
            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();

        }

        [MenuItem("Assets/GFrame/Table/Build JSON")]
        static void ExcelToJson()
        {
            string dataFolderPath = ProjectPathConfig.externalTablePath;
            string outJsonPath = FilePath.streamingAssetsPath4Config;
            IO.CheckDirAndCreate(dataFolderPath);

            string[] allTableFiles = Directory.GetFiles(dataFolderPath, "*.xlsx", SearchOption.AllDirectories);
            if (allTableFiles == null || allTableFiles.Length <= 0)
            {
                Debug.LogError("#No Table Found in" + dataFolderPath);
                return;
            }
            IO.CheckDirAndCreate(outJsonPath);

            for (int i = 0; i < allTableFiles.Length; i++)
            {
                EditorUtility.DisplayProgressBar("Hold on", "Processing", (float)(i + 1) / allTableFiles.Length);
                if (PathHelper.Path2Name(allTableFiles[i]).StartsWith("~"))
                {
                    continue;
                }

                string dictName = new DirectoryInfo(Path.GetDirectoryName(allTableFiles[i])).Name;
                string fileName = Path.GetFileNameWithoutExtension(allTableFiles[i]);

                //构造Excel工具类
                ExcelUtility excel = new ExcelUtility(allTableFiles[i]);
                //判断编码类型
                Encoding encoding = Encoding.GetEncoding("utf-8");
                //判断输出类型
                string output = outJsonPath + fileName + ".json";
                excel.ConvertToJson(output, encoding);

            }
            EditorUtility.ClearProgressBar();
            AssetDatabase.Refresh();
        }


        static string ReadExcelData(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            string fileContent = File.ReadAllText(fileName, UnicodeEncoding.Default);
            Debug.LogError(fileContent);

            string[] fileLineContent = fileContent.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
            string class_name = Path.GetFileNameWithoutExtension(fileName);
            if (fileLineContent != null)
            {
                //注释的名字
                string[] noteContents = fileLineContent[0].Split(new string[] { "," }, System.StringSplitOptions.None);
                //变量的名字
                string[] VariableNameContents = fileLineContent[1].Split(new string[] { "," }, System.StringSplitOptions.None);
                //变量类型的名字
                string[] TypeValue = fileLineContent[2].Split(new string[] { "," }, System.StringSplitOptions.None);

                /*———————————生成CS的Class类脚本————————————*/

                StringBuilder code = new StringBuilder();                //创建代码串
                                                                         //添加常见且必须的引用字符串
                code.Append("using UnityEngine; \n");
                code.Append("using System.Collections; \n");
                //产生类，所有可执行代码均在此类中运行
                code.Append("public class Class_" + class_name + " { \n\t");
                for (int i = 0; i < TypeValue.Length; i++)
                {
                    code.Append("public string ");
                    code.Append(VariableNameContents[i] + " { get; set; } " + "   //" + noteContents[i] + "\n\t");
                    if (TypeValue[i] == "int")
                    {
                        code.Append("public int _" + VariableNameContents[i] + " (){\n\t\t");
                        code.Append("int value = int.Parse(" + VariableNameContents[i] + ");\n\t\t");
                        code.Append("return value;\n\t");
                        code.Append("}\n\t");
                    }
                    else if (TypeValue[i] == "float")
                    {
                        code.Append("  public float _" + VariableNameContents[i] + " (){\n\t\t");
                        code.Append("float value = float.Parse(" + VariableNameContents[i] + ");\n\t\t");
                        code.Append("return value;\n\t");
                        code.Append("}\n\t");
                    }
                    else if (TypeValue[i] == "string")
                    {
                        code.Append("  public string _" + VariableNameContents[i] + " (){\n\t\t");
                        code.Append("string value = " + VariableNameContents[i] + ";\n\t\t");
                        code.Append("return value;\n\t");
                        code.Append("}\n\t");
                    }
                }
                code.Append("}\n\t");
                string CSharpFilePath = Application.dataPath + "/Scripts/Script_Doc_CD";
                string directName = Path.GetDirectoryName(CSharpFilePath);
                if (!Directory.Exists(directName))
                {
                    Directory.CreateDirectory(directName);
                }
                if (!Directory.Exists(CSharpFilePath))
                {
                    Directory.CreateDirectory(CSharpFilePath);
                }

                FileStream fs = new FileStream(CSharpFilePath + "/" + "/Class_" + class_name + ".cs", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(code.ToString());
                sw.Close(); fs.Close();
                //File.WriteAllText(CSharpFilePath + "/" + CDicdictName + "/Class_" + CDicfileName + ".cs", code.ToString(), Encoding.UTF8);
                Debug.Log("成功生成c#的Class文件" + class_name + ".cs" + "在目录:" + CSharpFilePath + " 中");

                /*———————————生成CS的Dictionary类脚本————————————*/

                StringBuilder code_Dic = new StringBuilder();                //创建代码串
                string docPath = "\"Json/Document/" + class_name + "\"";
                //添加常见且必须的引用字符串
                code_Dic.Append("using UnityEngine; \n");
                code_Dic.Append("using System.Collections.Generic; \n");
                //产生类，所有可执行代码均在此类中运行
                code_Dic.Append("public static class SD_" + class_name + " { \n\t");
                code_Dic.Append("public static Dictionary<string, Class_" + class_name + "> Class_Dic = JsonReader.ReadJson<Class_" + class_name + "> (" + docPath + ");\n\t");
                code_Dic.Append("}\n");
                string DicFilePath = Application.dataPath + "/Scripts/Script_Doc_SD";
                string DicName = Path.GetDirectoryName(DicFilePath);
                if (!Directory.Exists(DicName))
                {
                    Directory.CreateDirectory(DicName);
                }
                if (!Directory.Exists(DicFilePath))
                {
                    Directory.CreateDirectory(DicFilePath);
                }

                FileStream fs2 = new FileStream(DicFilePath + "/" + "/SD_" + class_name + ".cs", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw2 = new StreamWriter(fs2, Encoding.UTF8);
                sw2.Write(code_Dic.ToString());
                sw2.Close(); fs2.Close();
                //File.WriteAllText(DicFilePath + "/" + DDicdictName + "/SD_" + DDicfileName + ".cs", code_Dic.ToString(), Encoding.UTF8);
                Debug.Log("成功生成c#的Dic文件" + class_name + ".cs" + "在目录:" + DicFilePath + " 中");


                /*————————解析表格字符串————————————*/
                JsonMapper jsonData = new JsonMapper();
                for (int i = 3; i < fileLineContent.Length - 1; i++)
                {
                    string[] lineContents = fileLineContent[i].Split(new string[] { "," }, System.StringSplitOptions.None);
                    JsonData classLine = new JsonData();
                    for (int j = 1; j < lineContents.Length; j++)
                    {
                        classLine[VariableNameContents[j]] = lineContents[j];
                    }
                    //jsonData[lineContents[0]] = classLine;
                }


                string resultJson = jsonData.ToString();
                return resultJson;
            }
            return null;
        }





    }
}




