using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System;
using System.Reflection;
using UnityEditor.Callbacks;
using System.IO;

namespace GFrame
{

    public class AutoBuildAttribute
    {
        private const string NAMESPACE = EngineDefine.NAMESPACE;
        private const string EDITKEY = "AutoBindAttribute";
        static Dictionary<string, string> dicUIType = new Dictionary<string, string>()
        {
             {"Img", "Image"},
             {"Btn", "Button"},
             {"Txt", "Text"},
             {"Trans", "Transform"},
             {"Obj", "GameObject"}
             //{"Toggle","Toggle"}
        };

        #region  Bind绑定
        [MenuItem("Custom/Tools/AutoBind/AutoBuildAttributeByBind")]
        static public void AutoCreateAttributeByBind()
        {
            if (Selection.gameObjects.Length == 0)
                return;
            GameObject selectobj = Selection.gameObjects[0];
            WriteCode(selectobj);
            //if(selectobj)
        }

        static private void WriteCode(GameObject obj)
        {
            string fileName = obj.transform.name + "_AutoBind.cs";
            string dicName = Application.dataPath + "/Scripts/Game/UIScripts/" + obj.name;
            IO.CheckDirAndCreate(dicName);

            AutoBind[] uiBinds = obj.transform.GetComponentsInChildren<AutoBind>();
            List<AttrInfo> attrInfos = new List<AttrInfo>();
            foreach (AutoBind uiBind in uiBinds)
            {
                if (uiBind.transform.name.Contains("_"))
                {
                    string fieldName = uiBind.transform.name;
                    fieldName = fieldName.Replace("(", "");
                    fieldName = fieldName.Replace(")", "");


                    fieldName = fieldName.Replace("_", "");
                    fieldName = fieldName[0].ToString().ToUpper() + fieldName.Substring(1);
                    fieldName = "m_" + fieldName;

                    Transform targetTrans = uiBind.transform;
                    StringBuilder path = new StringBuilder();
                    while (targetTrans.parent != obj.transform)
                    {
                        targetTrans = targetTrans.parent;
                        path.Append(targetTrans.name + "/");

                    }
                    path.Append(uiBind.transform.name);

                    AttrInfo attrInfo = new AttrInfo();
                    if (!string.IsNullOrEmpty(uiBind.attrName))
                        attrInfo.attrName = uiBind.attrName;
                    else
                    {
                        attrInfo.attrName = uiBind.transform.name;
                    }
                    attrInfo.typeName = uiBind.type.ToString();
                    attrInfo.objName = uiBind.transform.name;
                    attrInfo.path = path.ToString();
                    attrInfos.Add(attrInfo);

                }
            }
            string filePath = Path.Combine(dicName, fileName);
            string fileMonoPath = Path.Combine(dicName, obj.transform.name + ".cs");
            IO.WriteFile(filePath, WriteNewFile(obj.transform.name, attrInfos), true);
            if (!IO.IsFileExist(fileMonoPath))
            {
                IO.WriteFile(fileMonoPath, WriteEmptyMono(obj.transform.name), true);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        #endregion


        [MenuItem("Custom/Tools/AutoBind/自动生成代码并绑定变量")]
        static public void AutoCreateAttribute()
        {
            //子物体以这种名字开头的话，则会被构建属性
            //如Img_Title Btn_Close

            //可能和已有的类重复
            if (Selection.gameObjects.Length == 0)
                return;
            GameObject selectobj = Selection.gameObjects[0];
            string name = selectobj.name;

            List<AttrInfo> attrInfos = GetAttrInfosInGameObject(selectobj);
            if (attrInfos.Count == 0) return;

            //var script = selectobj.GetComponent(name);
            string path = Application.dataPath + "/";
            string filePath = path + name + "_AutoBind.cs";
            string fileMonoPath = path + name + ".cs";
            if (!IO.IsFileExist(fileMonoPath))
            {
                IO.WriteFile(fileMonoPath, WriteEmptyMono(name), true);
            }
            IO.DelFile(filePath);
            IO.WriteFile(filePath, WriteNewFile(name, attrInfos), true);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorPrefs.SetString(EDITKEY, name);
        }

        static private List<AttrInfo> GetAttrInfosInGameObject(GameObject obj)
        {
            string name = obj.name;
            Transform[] childs = obj.GetComponentsInChildren<Transform>();

            List<AttrInfo> attrInfos = new List<AttrInfo>();
            foreach (Transform child in childs)
            {
                if (child.name.Contains("_"))
                {

                    string key = child.name.Split('_')[0];
                    string value;
                    if (dicUIType.TryGetValue(key, out value))
                    {
                        string fieldName = child.name;
                        fieldName = fieldName.Replace(" ", "");
                        fieldName = fieldName.Replace("(", "");
                        fieldName = fieldName.Replace(")", "");


                        fieldName = fieldName.Replace("_", "");
                        fieldName = fieldName[0].ToString().ToUpper() + fieldName.Substring(1);
                        fieldName = "m_" + fieldName;

                        Transform targetTrans = child;
                        string path = "";
                        while (targetTrans.parent != obj.transform)
                        {
                            targetTrans = targetTrans.parent;
                            path = targetTrans.name + "/" + path;
                        }
                        path += child.name;
                        AttrInfo attrInfo = new AttrInfo();
                        attrInfo.attrName = fieldName;
                        attrInfo.typeName = value;
                        attrInfo.objName = child.name;
                        attrInfo.path = path.ToString();
                        attrInfos.Add(attrInfo);
                    }
                }
            }

            return attrInfos;
        }

        static private string WriteEmptyMono(string className)
        {
            string namespaceStr = NAMESPACE;
            StringBuilder code = new StringBuilder();
            code.Append("using System;\n");
            code.Append("using System.Collections;\n");
            code.Append("using UnityEngine;\n");
            code.Append("using UnityEngine.UI;\n");
            code.Append("using GFrame;\n");
            code.Append("\n");
            code.Append("namespace " + namespaceStr + "\n");
            code.Append("{\n");
            code.Append("\tpublic partial class " + className + " : MonoBehaviour\n");
            code.Append("\t{\n");
            code.Append("\t}\n");
            code.Append("}");

            return code.ToString();
        }

        static private string WriteNewFile(string className, List<AttrInfo> attrInfos)
        {
            string namespaceStr = NAMESPACE;
            StringBuilder code = new StringBuilder();
            code.Append("using System;\n");
            code.Append("using System.Collections;\n");
            code.Append("using UnityEngine;\n");
            code.Append("using UnityEngine.UI;\n");
            code.Append("using GFrame;\n");
            code.Append("\n");
            code.Append("namespace " + namespaceStr + "\n");
            code.Append("{\n");
            code.Append("\tpublic partial class " + className + " : MonoBehaviour\n");
            code.Append("\t{\n");

            foreach (var attr in attrInfos)
            {
                code.Append("\t\t[SerializeField] private " + attr.typeName + " " + attr.attrName + ";\n");
            }
            code.Append("\t}\n");
            code.Append("}");

            return code.ToString();
        }

        // static private void ModifFile(string go, string path, List<AttrInfo> attrInfos)
        // {
        //     string insertTxt = "";
        //     for (int i = 0; i < attrInfos.Count; i++)
        //     {
        //         insertTxt += "[SerializeField] private " + attrInfos[i].typeName + " " + attrInfos[i].attrName + ";\n";
        //     }

        //     string content = File.ReadAllText(path);
        //     string findStr = "MonoBehaviour\n";
        //     int startIndex = content.IndexOf(findStr, 100);
        //     if (startIndex > 0)
        //     {
        //         Debug.LogError(startIndex);
        //         content = content.Insert(startIndex + findStr.Length + 5, insertTxt);
        //         File.WriteAllText(path, content);
        //         EditorPrefs.SetString(EDITKEY, go);
        //         AssetDatabase.Refresh();
        //     }
        // }

        [DidReloadScripts]
        static void BindScriptsToObj()
        {
            string objName = EditorPrefs.GetString(EDITKEY, "");
            if (!string.IsNullOrEmpty(objName))
            {
                EditorPrefs.SetString(EDITKEY, "");
                GameObject targetObj = GameObject.Find(objName);
                string nameStr = NAMESPACE + "." + objName;

                //knowledge point
                //https://blog.csdn.net/u010153703/article/details/52136530
                Type type = null;

                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    Type tt = asm.GetType(nameStr);
                    if (tt != null)
                    {
                        type = tt;
                        break;
                    }
                }
                Debug.LogError(type);

                if (type == null) return;
                var targetComponent = targetObj.GetComponent(type);
                if (targetObj.GetComponent(type) == null)
                {
                    targetComponent = targetObj.AddComponent(type);
                }

                List<AttrInfo> attrInfos = GetAttrInfosInGameObject(targetObj);
                //接下来进行模拟拖拽操作
                BindProperties(targetComponent, targetObj, type, attrInfos);
            }
        }

        static private void BindProperties(object obj, GameObject go, Type type, List<AttrInfo> attrInfos)
        {
            List<AttrInfo> tempChild = new List<AttrInfo>(attrInfos);
            FieldInfo[] infos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            for (int i = 0; i < infos.Length; i++)
            {

                string attrName = infos[i].Name;
                for (int x = tempChild.Count - 1; x >= 0; --x)
                {

                    if (tempChild[x].attrName == attrName)
                    {
                        BindPropertie(obj, go, infos[i], tempChild[x]);
                        tempChild.Remove(tempChild[x]);
                    }
                }
            }
        }

        static private void BindPropertie(object obj, GameObject go, FieldInfo info, AttrInfo attrInfo)
        {
            var child = go.transform.Find(attrInfo.path);
            info.SetValue(obj, GetObjByAttrType(child, attrInfo.typeName));
        }

        static private object GetObjByAttrType(Transform trans, string typeName)
        {
            switch (typeName)
            {
                case "GameObject":
                    return trans.gameObject;
                case "Transform":
                    return trans;
                default:
                    return trans.GetComponent(typeName);
            }
        }



        private class AttrInfo
        {
            public string typeName;//变量类型名字
            public string attrName;//文件中的变量名
            public string objName;//游戏物体名字
            public string path;//在父节点中的路径
        }
    }
}




