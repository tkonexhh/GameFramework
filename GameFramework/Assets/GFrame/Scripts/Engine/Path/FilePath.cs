using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class FilePath
    {
        private static string m_PersistentDataPath;
        private static string m_StreamingAssetsPath;
        private static string m_PersistentDataPath4Recorder;

        //外部目录
        public static string persistentDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(m_PersistentDataPath))
                {
                    m_PersistentDataPath = Application.persistentDataPath + "/";
                }

                return m_PersistentDataPath;
            }
        }

        // 内部目录
        public static string streamingAssetsPath
        {
            get
            {
                if (null == m_StreamingAssetsPath)
                {
#if UNITY_IPHONE && !UNITY_EDITOR
                    m_StreamingAssetsPath = Application.streamingAssetsPath + "/";
#elif UNITY_ANDROID && !UNITY_EDITOR
                    m_StreamingAssetsPath = Application.streamingAssetsPath + "/";
#elif (UNITY_STANDALONE_WIN) && !UNITY_EDITOR
                    m_StreamingAssetsPath = Application.streamingAssetsPath + "/";//GetParentDir(Application.dataPath, 2) + "/BuildRes/";
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
                    m_StreamingAssetsPath = Application.streamingAssetsPath + "/";
#else
                    //m_StreamingAssetsPath = GetParentDir(Application.dataPath, 1) + "/BuildRes/standalone/";
                    m_StreamingAssetsPath = Application.streamingAssetsPath + "/";
                    m_StreamingAssetsPath = m_StreamingAssetsPath.Replace("\\", "/");
#endif
                }

                return m_StreamingAssetsPath;
            }
        }

        public static string persistentDataPath4Recorder
        {
            get
            {
                if (string.IsNullOrEmpty(m_PersistentDataPath4Recorder))
                {
                    m_PersistentDataPath4Recorder = persistentDataPath + "save/";
                    IO.CheckDirAndCreate(m_PersistentDataPath4Recorder);
                }

                return m_PersistentDataPath4Recorder;
            }
        }
    }

}
