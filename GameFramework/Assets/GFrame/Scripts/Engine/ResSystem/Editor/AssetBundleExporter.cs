using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace GFrame
{

    public class AssetBundleExporter
    {
        [MenuItem("Assets/GFrame/Asset/构建AB")]
        public static void BuildAllAssetBundles()
        {
            // AB包输出路径
            string outPath = FilePath.streamingAssetsPath + "Res";
            CheckDirAndCreate(outPath);
            BuildPipeline.BuildAssetBundles(outPath, 0, EditorUserBuildSettings.activeBuildTarget);

            // 刚创建的文件夹和目录能马上再Project视窗中出现
            AssetDatabase.Refresh();
        }

        public static void CheckDirAndCreate(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    }
}




