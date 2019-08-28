using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ProjectPathConfig
    {
        public const string AppConfigPath = "Config/AppConfig";
        public static string exportRootFolder
        {
            get
            {
                return FilePath.streamingAssetsPath + "Assets/";
            }
        }
    }
}




