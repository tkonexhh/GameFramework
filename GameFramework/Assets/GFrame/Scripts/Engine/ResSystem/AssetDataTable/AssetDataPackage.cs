using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{

    public class AssetDataPackage
    {
        [Serializable]
        public class SerializeData
        {
            private string m_Key;
            private ABUnit m_ABUnit;
            private AssetData[] m_AssetDataArray;
            private long m_BuildTime;

            public string key
            {
                get { return m_Key; }
                set { m_Key = value; }
            }

            public ABUnit abUnit
            {
                get { return m_ABUnit; }
                set { m_ABUnit = value; }
            }

            public AssetData[] assetDataArray
            {
                get { return m_AssetDataArray; }
                set { m_AssetDataArray = value; }
            }

            public long buildTime
            {
                get { return m_BuildTime; }
                set { m_BuildTime = value; }
            }
        }

        private string m_Key;
        private string m_Path;
        private long m_BuildTime;

        private ABUnit m_ABUnit;
        //private List<ABUnit> m_ABUnitLst;
        private Dictionary<string, AssetData> m_AssetDataMap;

        public string key
        {
            get { return m_Key; }
        }

        public AssetDataPackage(string key, string path, long buildtime)
        {
            m_Key = key;
            m_Path = path;
            m_BuildTime = buildtime;
        }

        public AssetDataPackage(SerializeData data, string path)
        {
            m_Key = data.key;
            m_Path = path;
            m_BuildTime = data.buildTime;
        }

        public void Reset()
        {
            //if (m_ABUnitLst != null) m_ABUnitLst.Clear();
            if (m_AssetDataMap != null) m_AssetDataMap.Clear();
        }

        public void Save(string path)
        {
            SerializeData data = GetSerializeData();
            string outPath = string.Format("{0}{1}", path, ProjectPathConfig.abTableFileName);
            if (SerializeHelper.SerializeBinary(outPath, data))
            {
                Log.i("#Success Save AssetDataTable:" + outPath);
            }
            else
            {
                Log.e("#Failed Save AssetDataTable:" + outPath);
            }
        }

        public SerializeData GetSerializeData()
        {
            SerializeData data = new SerializeData();
            data.key = m_Key;
            data.buildTime = m_BuildTime;
            if (m_ABUnit != null)
            {
                data.abUnit = m_ABUnit;
            }

            if (m_AssetDataMap != null)
            {
                AssetData[] acArray = new AssetData[m_AssetDataMap.Count];
                int index = 0;
                foreach (var item in m_AssetDataMap)
                {
                    acArray[index++] = item.Value;
                }

                data.assetDataArray = acArray;
            }
            return data;
        }

        public bool AddAssetBundle(string name, string[] depends, string md5, int fileSize, long buildTime)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (m_ABUnit == null)
            {
                m_ABUnit = new ABUnit(name, depends, md5, fileSize, buildTime);
            }

            AssetData config = GetAssetData(name);
            if (config != null)
            {
                Debug.LogError("#Already add AssetData");
                return false;
            }

            // m_ABUnitLst.Add(new ABUnit(name, depends, md5, fileSize, buildTime));
            //int index = 1;//m_ABUnitLst.Count - 1;
            AddAssetData(new AssetData(name, eResType.kABAsset));
            return true;
        }

        private AssetData GetAssetData(string name)
        {
            if (m_AssetDataMap == null)
            {
                m_AssetDataMap = new Dictionary<string, AssetData>();
            }
            string key = name.ToLower();
            AssetData assetData;
            m_AssetDataMap.TryGetValue(key, out assetData);
            return assetData;
        }

        public bool AddAssetData(AssetData assetData)
        {
            if (m_AssetDataMap == null)
            {
                m_AssetDataMap = new Dictionary<string, AssetData>();
            }

            string key = assetData.assetName.ToLower();

            //TODO ?????
            if (key.EndsWith(" "))
            {
                Log.e("#Asset Name Is InValid:" + key);
            }

            if (m_AssetDataMap.ContainsKey(key))
            {
                AssetData oldAsset = GetAssetData(key);
                string msg = string.Format("#Aleady Add AssetData :{0} ", assetData.assetName);
                Log.w(msg);
                return false;
            }

            m_AssetDataMap.Add(key, assetData);
            return true;
        }

        public ABUnit GetABUnit(string name)
        {
            AssetData data = GetAssetData(name);
            if (data == null) return null;
            if (m_ABUnit == null) return null;

            return m_ABUnit;//m_ABUnitLst[data.assetBundleIndex];
        }
    }
}




