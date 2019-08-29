using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace GFrame.UnityEditor
{

    public class AppConfigEditor
    {
        [MenuItem("Assets/GFrame/Config/Build AppConfig")]
        public static void BuildAppConfig()
        {
            AppConfig data = null;
            string folderPath = "Assets/GFrame/Resources/Config";//EditorUtils.GetSelectedDirAssetsPath();
            string spriteDataPath = folderPath + "/AppConfig.asset";

            data = AssetDatabase.LoadAssetAtPath<AppConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<AppConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("Create App Config In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}




