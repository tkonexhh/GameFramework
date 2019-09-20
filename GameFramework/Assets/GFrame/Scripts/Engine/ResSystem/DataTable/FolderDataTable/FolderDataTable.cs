using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{
    //根据资源进出维护一个资源数据库
    public class FolderDataTable : TSingleton<FolderDataTable>
    {
        [Serializable]
        public class SerializeData
        {
            public FolderData.SerializeData[] m_Datas;
        }

        [SerializeField]
        private static bool m_IsFirstLoad = false;
        string m_OutPath = ProjectPathConfig.resTableFilePath;
        private List<FolderData> m_FolderDataLst = new List<FolderData>();
        private Dictionary<string, FolderData> m_FolderDataMap = new Dictionary<string, FolderData>();

        public List<FolderData> GetFolderDataLst()
        {
            return m_FolderDataLst;
        }


        public void AddFolderData(string path)
        {
            Load();
            string assetKey = PathHelper.AssetPath2Name(path);
            FolderData data = null;
            if (m_FolderDataMap.TryGetValue(assetKey, out data))
            {
                Log.e("#Already Add Asset In" + path);
                return;
            }
            data = new FolderData(assetKey, path);
            m_FolderDataLst.Add(data);
            m_FolderDataMap.Add(assetKey, data);
            Save();
        }


        public void RemoveFolderData(string path)
        {
            Load();
            string assetKey = PathHelper.AssetPath2Name(path);
            FolderData data = null;
            if (!m_FolderDataMap.TryGetValue(assetKey, out data))
            {
                Log.e("#Not Find Asset In" + path);
                return;
            }
            m_FolderDataLst.Remove(data);
            m_FolderDataMap.Remove(assetKey);
            //Save();
            Save();
        }

        public void Save()
        {
            SerializeData totalData = new SerializeData();
            totalData.m_Datas = new FolderData.SerializeData[m_FolderDataLst.Count];
            for (int i = 0; i < m_FolderDataLst.Count; i++)
            {
                FolderData.SerializeData data = GetSerializeFolderData(m_FolderDataLst[i]);
                totalData.m_Datas[i] = data;
            }
            Debug.LogError("count:" + m_FolderDataLst.Count);
            SerializeHelper.SerializeBinary(m_OutPath, totalData);
            FolderDataConfig.S.Refesh();
            // Debug.LogError("Save:" + path);
            //Load();
        }


        public void Load()
        {
            if (!Platform.IsEditor)
            {
                return;
            }
            if (!m_IsFirstLoad)
            {
                Log.i("#Init FolderDataTable");
                m_IsFirstLoad = true;
                if (IO.IsFileExist(m_OutPath))
                {
                    return;
                }
                object obj = SerializeHelper.DeserializeBinary(m_OutPath);
                if (obj == null)
                {
                    Log.e("#Deserialize Failed At:" + m_OutPath);
                }

                SerializeData data = obj as SerializeData;
                m_FolderDataLst.Clear();
                m_FolderDataMap.Clear();
                for (int i = 0; i < data.m_Datas.Length; ++i)
                {
                    Debug.LogError(i);
                    FolderData folderData = GetFolderData(data.m_Datas[i]);
                    m_FolderDataLst.Add(folderData);
                    m_FolderDataMap.Add(folderData.assetName, folderData);
                }
            }
        }

        private FolderData.SerializeData GetSerializeFolderData(FolderData data)
        {
            FolderData.SerializeData floderData = new FolderData.SerializeData();
            floderData.path = data.path;
            return floderData;
        }

        private FolderData GetFolderData(FolderData.SerializeData serializeData)
        {
            FolderData data = new FolderData(serializeData.name, serializeData.path);
            return data;
        }
    }
}




