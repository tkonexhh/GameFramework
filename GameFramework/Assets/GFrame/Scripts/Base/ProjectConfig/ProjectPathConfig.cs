using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ProjectPathConfig : ScriptableObject
    {

        private static ProjectPathConfig s_Instace;
        public static ProjectPathConfig S
        {
            get
            {
                if (s_Instace == null)
                {
                    s_Instace = new ProjectPathConfig();
                }
                return s_Instace;
            }
        }

        #region 
        [SerializeField] private string m_AppConfigPath = "Config/AppConfig";
        [SerializeField] private string m_ABRelativePath = "Assets/";
        #endregion


        public static string appConfigPath
        {
            get
            {
                return S.m_AppConfigPath;
            }
        }

        public static string abRelativePath
        {
            get
            {
                return S.m_ABRelativePath;
            }
        }

    }
}




