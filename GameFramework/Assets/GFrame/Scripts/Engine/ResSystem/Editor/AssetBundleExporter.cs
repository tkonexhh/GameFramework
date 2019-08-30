using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace GFrame.UnityEditor
{

    public class AssetBundleExporter
    {
        static string outPath = FilePath.streamingAssetsPath + "AB";

        [MenuItem("Assets/GFrame/Asset/构建AB_Current")]
        public static void BuildAllAssetBundles()
        {
            Log.i("Start Build All AssetBundles.");
            AssetBundleBuilder.BuildAB(outPath + "/" + EditorUserBuildSettings.activeBuildTarget.ToString(), EditorUserBuildSettings.activeBuildTarget);
        }

        [MenuItem("Assets/GFrame/Asset/构建AB_IOS")]
        public static void BuildAllAssetBundlesIOS()
        {
            AssetBundleBuilder.BuildAB(outPath + "/IOS", BuildTarget.iOS);
        }

        [MenuItem("Assets/GFrame/Asset/构建AB_Android")]
        public static void BuildAllAssetBundlesAndroid()
        {
            AssetBundleBuilder.BuildAB(outPath + "/Android", BuildTarget.Android);
        }
    }
}




