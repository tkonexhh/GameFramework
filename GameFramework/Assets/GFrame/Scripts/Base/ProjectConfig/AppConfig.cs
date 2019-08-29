using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    //[CreateAssetMenu(menuName = "GFrame/Config/Create AppConfig", fileName = "AppConfig")]
    public class AppConfig : ScriptableObject
    {
        [SerializeField] LogLevel m_LogLevel;
        [SerializeField] LogLevel m_FileLogLevel;


        #region 初始化过程
        private static AppConfig s_Instance = null;

        private static AppConfig LoadInstance()
        {
            var obj = Resources.Load(ProjectPathConfig.AppConfigPath) as Object;

            if (obj == null)
            {
                Log.e("Not Find AppConfig");
                return null;
            }

            s_Instance = obj as AppConfig;
            return s_Instance;
        }

        public static AppConfig S
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = LoadInstance();
                }

                return s_Instance;
            }
        }

        #endregion

        public void InitAppConfig()
        {
            LogMgr.S.fileLogLevel = m_FileLogLevel;
            Log.i("Init[AppConfig]");
            LogMgr.S.logLevel = m_LogLevel;

        }
    }
}