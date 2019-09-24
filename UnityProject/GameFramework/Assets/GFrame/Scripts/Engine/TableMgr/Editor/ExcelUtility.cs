using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Excel;
using System.Data;
using System.IO;
//using Newtonsoft.Json;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System;

namespace GFrame
{


    public class ExcelUtility
    {

        /// <summary>
        /// 表格数据集合
        /// </summary>
        private DataSet mResultSet;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="excelFile">Excel file.</param>
        public ExcelUtility(string excelFile)
        {
            FileStream mStream = File.Open(excelFile, FileMode.Open, FileAccess.Read);
            IExcelDataReader mExcelReader = ExcelReaderFactory.CreateOpenXmlReader(mStream);
            mResultSet = mExcelReader.AsDataSet();
        }

        // /// <summary>
        // /// 转换为实体类列表
        // /// </summary>
        // public List<T> ConvertToList<T>()
        // {
        //     //判断Excel文件中是否存在数据表
        //     if (mResultSet.Tables.Count < 1)
        //         return null;
        //     //默认读取第一个数据表
        //     DataTable mSheet = mResultSet.Tables[0];

        //     //判断数据表内是否存在数据
        //     if (mSheet.Rows.Count < 1)
        //         return null;

        //     //读取数据表行数和列数
        //     int rowCount = mSheet.Rows.Count;
        //     int colCount = mSheet.Columns.Count;

        //     //准备一个列表以保存全部数据
        //     List<T> list = new List<T>();

        //     //读取数据
        //     for (int i = 1; i < rowCount; i++)
        //     {
        //         //创建实例
        //         Type t = typeof(T);
        //         ConstructorInfo ct = t.GetConstructor(System.Type.EmptyTypes);
        //         T target = (T)ct.Invoke(null);
        //         for (int j = 0; j < colCount; j++)
        //         {
        //             //读取第1行数据作为表头字段
        //             string field = mSheet.Rows[0][j].ToString();
        //             object value = mSheet.Rows[i][j];
        //             //设置属性值
        //             SetTargetProperty(target, field, value);
        //         }

        //         //添加至列表
        //         list.Add(target);
        //     }

        //     return list;
        // }


        private class InterKey
        {
            public string type;
            public string attr;
            public InterKey(string type, string attr)
            {
                this.type = type;
                this.attr = attr;
            }
        }

        /// <summary>
        /// 转换为Json
        /// </summary>
        /// <param name="JsonPath">Json文件路径</param>
        /// <param name="Header">表头行数</param>
        public void ConvertToJson(string JsonPath, Encoding encoding)
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count <= 4)
                return;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //准备一个列表存储整个表的数据
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();

            //读取数据
            for (int i = 4; i < rowCount; i++)
            {

                if (string.IsNullOrEmpty(mSheet.Rows[i][0].ToString()))//没有Key数据
                {
                    break;
                }
                Dictionary<string, string> row = new Dictionary<string, string>();
                for (int j = 0; j < colCount; j++)
                {
                    if (mSheet.Rows[2][j].ToString() == "N")
                    {
                        continue;
                    }

                    //读取第4行数据作为表头字段
                    string field = mSheet.Rows[3][j].ToString();
                    if (string.IsNullOrEmpty(field))
                    {
                        break;
                    }
                    //Key-Value对应
                    row[field] = mSheet.Rows[i][j].ToString();
                }

                //添加到表数据中
                table.Add(row);
            }

            SerializeHelper.SerializeJson(JsonPath, table, false);
        }

        /// <summary>
        /// 转换为CSV
        /// </summary>
        public void ConvertToCSV(string CSVPath, Encoding encoding)
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count < 1)
                return;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //创建一个StringBuilder存储数据
            StringBuilder stringBuilder = new StringBuilder();

            //读取数据
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    //使用","分割每一个数值
                    stringBuilder.Append(mSheet.Rows[i][j] + ",");
                }
                //使用换行符分割每一行
                stringBuilder.Append("\r\n");
            }

            //写入文件
            using (FileStream fileStream = new FileStream(CSVPath, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, encoding))
                {
                    textWriter.Write(stringBuilder.ToString());
                }
            }

        }

        /// <summary>
        /// 导出为Xml
        /// </summary>
        public void ConvertToXml(string XmlFile)
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count < 1)
                return;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //创建一个StringBuilder存储数据
            StringBuilder stringBuilder = new StringBuilder();
            //创建Xml文件头
            stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            stringBuilder.Append("\r\n");
            //创建根节点
            stringBuilder.Append("<Table>");
            stringBuilder.Append("\r\n");
            //读取数据
            for (int i = 1; i < rowCount; i++)
            {
                //创建子节点
                stringBuilder.Append("  <Row>");
                stringBuilder.Append("\r\n");
                for (int j = 0; j < colCount; j++)
                {
                    stringBuilder.Append("   <" + mSheet.Rows[0][j].ToString() + ">");
                    stringBuilder.Append(mSheet.Rows[i][j].ToString());
                    stringBuilder.Append("</" + mSheet.Rows[0][j].ToString() + ">");
                    stringBuilder.Append("\r\n");
                }
                //使用换行符分割每一行
                stringBuilder.Append("  </Row>");
                stringBuilder.Append("\r\n");
            }
            //闭合标签
            stringBuilder.Append("</Table>");
            //写入文件
            using (FileStream fileStream = new FileStream(XmlFile, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    textWriter.Write(stringBuilder.ToString());
                }
            }
        }

        /// <summary>
        /// 设置目标实例的属性
        /// </summary>
        private void SetTargetProperty(object target, string propertyName, object propertyValue)
        {
            //获取类型
            Type mType = target.GetType();
            //获取属性集合
            PropertyInfo[] mPropertys = mType.GetProperties();
            foreach (PropertyInfo property in mPropertys)
            {
                if (property.Name == propertyName)
                {
                    property.SetValue(target, Convert.ChangeType(propertyValue, property.PropertyType), null);
                }
            }
        }

        public void WriteDataFile(string filePath)
        {
            string fileName = PathHelper.Path2Name(filePath);
            string samePath = PathHelper.GetSamePart(filePath, ProjectPathConfig.externalTablePath);
            string externPath = "";// PathHelper.GetParentDir(filePath.Substring(samePath.Length)); ;
            if (!string.Equals(samePath, ProjectPathConfig.externalTablePath))
            {
                externPath = PathHelper.GetParentDir(filePath.Substring(samePath.Length));
            }


            fileName = fileName.Substring(0, 1).ToUpper() + fileName.Substring(1);
            DataTable mSheet = mResultSet.Tables[0];
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;
            if (mSheet.Rows.Count <= 4)
                return;
            CreateTDData(fileName, externPath, mSheet, rowCount, colCount);
            CreateTDDataTable(fileName, externPath, mSheet, rowCount, colCount);
            CreateTDDataExtend(fileName, externPath, mSheet, rowCount, colCount);
            CreateTDDataTableExtend(fileName, externPath, mSheet, rowCount, colCount);
        }

        #region 生成TDData的Class类脚本
        private void CreateTDData(string fileName, string externPath, DataTable mSheet, int rowCount, int colCount)
        {
            string className = "TD" + fileName;
            StringBuilder code = new StringBuilder();
            code.Append("using UnityEngine; \n");
            code.Append("using System.Collections.Generic; \n");
            code.Append("using System.Collections; \n");
            code.Append("using GFrame; \n");
            code.Append("namespace Main.Game\n{\n");
            code.Append("\tpublic partial class " + className + " \n\t");
            code.Append("{\n\t\t");

            List<InterKey> attrLst = new List<InterKey>();

            for (int i = 0; i < colCount; i++)
            {
                if (mSheet.Rows[1][i].ToString() == "N")//注释
                {
                    continue;
                }
                if (string.IsNullOrEmpty(mSheet.Rows[1][i].ToString()))
                {
                    break;
                }

                string type = mSheet.Rows[2][i].ToString();
                string attr = mSheet.Rows[3][i].ToString();
                code.Append("private " + type + " m_" + attr + ";\n\t\t");
                code.Append("/// <summary>\n\t\t/// " + mSheet.Rows[0][i] + "\n\t\t ///</summary>\n\t\t");
                code.Append("public " + type + " " + attr + "\n\t\t{\n\t\t\tget\n\t\t\t{\n\t\t\t\treturn m_" + attr + ";\n\t\t\t}\n\t\t}\n\t");
                code.Append("\t");

                InterKey key = new InterKey(type, attr);
                attrLst.Add(key);
            }
            code.Append("\n\t\t");
            code.Append("public static Dictionary<string, int> GetFieldHeadIndex()\n\t\t{\n\t\t\t");
            code.Append("Dictionary<string, int> ret = new Dictionary<string, int>(" + attrLst.Count + ");\n\t\t\t");
            for (int i = 0; i < attrLst.Count; i++)
            {
                code.Append("ret.Add(\"" + attrLst[i].attr + "\", " + i + ");\n\t\t\t");
            }
            code.Append("return ret;\n\t\t}\n\t");

            code.Append("public void BindData(Dictionary<string, string> dataMap)\n\t{\n\t\t");
            code.Append("Dictionary<string, int> headIndexMap = GetFieldHeadIndex();\n\t\t");
            code.Append("foreach (var key in dataMap.Keys)\n{\n");
            code.Append("int col = -1;\n\t\t");
            code.Append("string value = dataMap[key];\n\t\t");
            code.Append("if (headIndexMap.TryGetValue(key, out col))\n\t{\n\t\t");
            code.Append("switch (col)\n\t{\n\t\t");
            for (int i = 0; i < attrLst.Count; i++)
            {
                code.Append("case " + i + ":\n\t");

                if (attrLst[i].type == "int")
                {
                    code.Append("m_" + attrLst[i].attr + " = int.Parse(value);\n\t\t");
                }
                else if (attrLst[i].type == "float")
                {
                    code.Append("m_" + attrLst[i].attr + " = float.Parse(value);\n\t\t");
                }
                else if (attrLst[i].type == "string")
                {
                    code.Append("m_" + attrLst[i].attr + " = value;\n\t\t");
                }
                else if (attrLst[i].type == "bool")
                {
                    code.Append("m_" + attrLst[i].attr + " = value.ToLower().Equals(\"true\");\n\t\t");
                }
                //code.Append(attrLst[i]+ " = ");
                code.Append("break;\n");
            }

            code.Append("default:\n\tbreak;\n}\n}\n}\n}\n");



            code.Append("}\n");
            code.Append("}");
            string CSharpFilePath = ProjectPathConfig.tableScriptOutPutPath + "/Generate/" + externPath + "/";
            IO.CheckDirAndCreate(CSharpFilePath);

            string fullFileName = className + ".cs";
            IO.WriteFile(CSharpFilePath + fullFileName, code.ToString());
            attrLst.Clear();
            attrLst = null;
            code = null;
            //Log.i("#成功生成c#的Class文件" + className + ".cs" + "在目录:" + CSharpFilePath + " 中");
        }

        private void CreateTDDataTable(string fileName, string externPath, DataTable mSheet, int rowCount, int colCount)
        {
            string className = "TD" + fileName;
            string tableClassName = className + "Table";
            string keyType = mSheet.Rows[2][0].ToString();
            string keyName = mSheet.Rows[3][0].ToString();
            StringBuilder code = new StringBuilder();
            code.Append("using UnityEngine; \n");
            code.Append("using System.Collections.Generic; \n");
            code.Append("using System.Collections; \n");
            code.Append("using GFrame; \n");
            code.Append("namespace Main.Game\n{\n");
            code.Append("\tpublic partial class " + tableClassName + "\n\t");
            code.Append("{\n\t\t");
            code.Append("private static Dictionary<" + keyType + ", " + className + "> m_DataCache = new Dictionary<" + keyType + ", " + className + ">();\n\t\t");
            code.Append("private static List<" + className + "> m_DataList = new List<" + className + ">();\n\t\t");
            code.Append("public static int count\n\t\t");
            code.Append("{\n\t\t\t");
            code.Append("get\n\t\t\t");
            code.Append("{\n\t\t\t\t");
            code.Append("return m_DataCache.Count;\n\t\t\t");
            code.Append("}\n\t\t");
            code.Append("}\n\t\t");

            code.Append("public static List<" + className + "> dataList\n\t\t");
            code.Append("{\n\t\t\tget\n\t\t\t{\n\t\t\t\treturn m_DataList;\n\t\t\t}\n\t\t}\n\t\t");

            code.Append("public static " + className + " GetData(" + keyType + " key)\n\t\t{\n\t\t\t");
            code.Append("if (m_DataCache.ContainsKey(key))\n\t\t\t{\n\t\t\t\t");
            code.Append("return m_DataCache[key];\n\t\t\t}\n\t\t\t");
            code.Append("else\n\t\t\t{\n\t\t\t\t");
            code.Append("Log.w(string.Format(\"Can't find key {0} in " + className + "\", key));\n\t\t\t\treturn null;\n\t\t\t}\n\t\t}\n\t");

            code.Append("public static void Parse()\n\t\t{\n\t\t\t");
            code.Append("m_DataCache.Clear();\n\t\t");
            code.Append("m_DataList.Clear();\n\t\t");
            code.Append("List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + \"" + fileName + ".json" + "\", false);");
            code.Append("int count = allDataList.Count;\n\t\t");
            code.Append("for (int i = 0; i < count; i++)\n\t\t{\n\t\t\t");
            code.Append("Dictionary<string, string> dataMap = allDataList[i];\n\t\t");
            code.Append(className + " data = new " + className + "();\n\t\t");
            code.Append("data.BindData(dataMap);\n\t\t");
            code.Append("m_DataList.Add(data);\n\t\t");
            code.Append("m_DataCache.Add(data." + keyName + ", data);\n\t\t");
            code.Append("}\n\t\t");
            code.Append("}\n\t\t");


            code.Append("}\n\t");
            code.Append("}");

            string CSharpFilePath = ProjectPathConfig.tableScriptOutPutPath + "/Generate/" + externPath + "/";
            IO.CheckDirAndCreate(CSharpFilePath);

            string fullFileName = tableClassName + ".cs";
            IO.WriteFile(CSharpFilePath + fullFileName, code.ToString());
            //Log.i("#成功生成c#的Class文件" + fullFileName + "在目录:" + CSharpFilePath + " 中");

        }

        private void CreateTDDataExtend(string fileName, string externPath, DataTable mSheet, int rowCount, int colCount)
        {
            string className = "TD" + fileName + "Extend";

            StringBuilder code = new StringBuilder();
            code.Append("using UnityEngine; \n");
            code.Append("using System.Collections.Generic; \n");
            code.Append("using System.Collections; \n");
            code.Append("using GFrame; \n");
            code.Append("namespace Main.Game\n{\n");

            code.Append("}");


            string CSharpFilePath = ProjectPathConfig.tableScriptOutPutPath + "/Extend/" + externPath + "/";
            IO.CheckDirAndCreate(CSharpFilePath);
            string fullFileName = className + ".cs";
            IO.WriteFile(CSharpFilePath + fullFileName, code.ToString());
        }

        private void CreateTDDataTableExtend(string fileName, string externPath, DataTable mSheet, int rowCount, int colCount)
        {
            string className = "TD" + fileName;
            string tableClassName = className + "TableExtend";

            StringBuilder code = new StringBuilder();
            code.Append("using UnityEngine; \n");
            code.Append("using System.Collections.Generic; \n");
            code.Append("using System.Collections; \n");
            code.Append("using GFrame; \n");
            code.Append("namespace Main.Game\n{\n");

            code.Append("}");

            string CSharpFilePath = ProjectPathConfig.tableScriptOutPutPath + "/Extend/" + externPath + "/";
            IO.CheckDirAndCreate(CSharpFilePath);
            string fullFileName = tableClassName + ".cs";
            IO.WriteFile(CSharpFilePath + fullFileName, code.ToString());
        }

        #endregion
    }
}
