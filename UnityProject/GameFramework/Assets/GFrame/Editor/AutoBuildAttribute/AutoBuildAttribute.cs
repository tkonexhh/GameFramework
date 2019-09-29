using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System;
using System.Reflection;
using Main.Game;
using System.IO;

namespace GFrame
{

    public class AutoBuildAttribute
    {


        [MenuItem("Custom/Tools/AutoBuildAttribute")]
        static public void AutoCreateAttribute()
        {
            //子物体以这种名字开头的话，则会被构建属性
            //如Img_Title Btn_Close
            var dicUIType = new Dictionary<string, string>();

            dicUIType.Add("Img", "Image");
            dicUIType.Add("Btn", "Button");
            dicUIType.Add("Txt", "Text");
            dicUIType.Add("Trans", "Transform");
            dicUIType.Add("Obj", "GameObject");

            //可能和已有的类重复
            GameObject[] selectobjs = Selection.gameObjects;
            foreach (GameObject obj in selectobjs)
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
                            fieldName = fieldName.Replace("_", "");
                            fieldName = fieldName[0].ToString().ToUpper() + fieldName.Substring(1);
                            fieldName = "m_" + fieldName;

                            Transform targetTrans = child;
                            StringBuilder path = new StringBuilder();
                            while (targetTrans.parent != obj.transform)
                            {
                                targetTrans = targetTrans.parent;
                                path.Append(targetTrans.name + "/");

                            }
                            path.Append(child.name);

                            AttrInfo attrInfo = new AttrInfo();
                            attrInfo.attrName = fieldName;
                            attrInfo.typeName = value;
                            attrInfo.objName = child.name;
                            attrInfo.path = path.ToString();
                            attrInfos.Add(attrInfo);
                        }
                    }
                }


                if (attrInfos.Count == 0) continue;

                var script = obj.GetComponent(name);

                if (script == null)
                {
                    string code = WriteFile(name, attrInfos);

                    string filePath = Application.dataPath + "/" + name + ".cs";
                    IO.WriteFile(filePath, code.ToString(), true);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    string nameStr = EngineDefine.NAMESPACE_DOT + name;

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

                    //TODO 第一次创建的时候没有信息，挂不上去
                    Debug.LogError(type);

                    if (type == null) return;

                    var targetComponent = obj.AddComponent(type);

                    //接下来进行模拟拖拽操作
                    BindProperties(targetComponent, obj, type, attrInfos);
                }
                else
                {
                    //当前已经挂上了制定的脚本
                    //修改脚本
                    FieldInfo[] fieldInfos = script.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    List<FieldInfo> currentInfos = new List<FieldInfo>(fieldInfos);

                    List<AttrInfo> needAddInfo = new List<AttrInfo>();
                    for (int i = attrInfos.Count - 1; i >= 0; --i)
                    {
                        bool alreadyHas = false;
                        for (int j = currentInfos.Count - 1; j >= 0; --j)
                        {

                            if (currentInfos[j].Name == attrInfos[i].attrName)
                            {
                                //Debug.LogError(attrInfos[i].attrName);
                                currentInfos.Remove(currentInfos[j]);
                                alreadyHas = true;
                            }
                        }

                        if (!alreadyHas)
                        {
                            needAddInfo.Add(attrInfos[i]);
                        }
                    }

                    if (needAddInfo.Count == 0) return;


                    var monoScript = MonoScript.FromMonoBehaviour((MonoBehaviour)script);
                    string scriptPath = AssetDatabase.GetAssetPath(monoScript.GetInstanceID());

                    FileStream fs = new FileStream(scriptPath, FileMode.Open, FileAccess.Write);
                    byte[] bytes = new byte[1024];
                    int count = (int)fs.Length;
                    fs.Read(bytes, 0, count);

                    string scriptStr = new UTF8Encoding().GetString(bytes);


                    fs.Flush();
                    fs.Close();
                    Debug.LogError(scriptStr);
                }

            }
        }

        static private string WriteFile(string className, List<AttrInfo> attrInfos)
        {
            string namespaceStr = EngineDefine.NAMESPACE;
            StringBuilder code = new StringBuilder();
            code.Append("using System;\n");
            code.Append("using System.Collections;\n");
            code.Append("using UnityEngine;\n");
            code.Append("using UnityEngine.UI;\n");
            code.Append("using GFrame;\n");
            code.Append("\n");
            code.Append("namespace " + namespaceStr + "\n");
            code.Append("{\n");
            code.Append("\tpublic class " + className + " : MonoBehaviour\n");
            code.Append("\t{\n");

            foreach (var attr in attrInfos)
            {
                code.Append("\t\t[SerializeField] private " + attr.typeName + " " + attr.attrName + ";\n");
            }
            code.Append("\t}\n");
            code.Append("}");

            return code.ToString();
        }

        static private void BindProperties(object obj, GameObject go, Type type, List<AttrInfo> attrInfos)
        {
            List<AttrInfo> tempChild = new List<AttrInfo>(attrInfos);
            FieldInfo[] infos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            for (int i = 0; i < infos.Length; i++)
            {
                string typeName = infos[i].Name;
                for (int x = tempChild.Count - 1; x >= 0; --x)
                {
                    if (tempChild[x].attrName == typeName)
                    {
                        var child = go.transform.Find(tempChild[x].path);
                        infos[i].SetValue(obj, GetObjByAttrType(child, tempChild[x].typeName));
                        tempChild.Remove(tempChild[x]);
                    }

                }
            }
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




