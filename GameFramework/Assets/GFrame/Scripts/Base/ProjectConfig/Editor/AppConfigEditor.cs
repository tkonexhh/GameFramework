using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace GFrame.UnityEditor
{

    public class AppConfigEditor
    {
        private const string CONFIG_NAME = "AppConfig.asset";

        [MenuItem("Assets/GFrame/Config/Build AppConfig")]
        public static void BuildAppConfig()
        {
            BaseConfigEditor<AppConfig>.BuildConfig(CONFIG_NAME);
        }
    }
}




