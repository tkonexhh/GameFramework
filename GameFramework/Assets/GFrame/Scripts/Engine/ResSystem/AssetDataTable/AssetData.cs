using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{
    [Serializable]
    public class AssetData
    {
        private string m_AssetName;
        private short m_ResType;
        private int m_Index;
        private int m_AssetBundleIndex;

        public string assetName
        {
            get { return m_AssetName; }
        }
        public int assetBundleIndex
        {
            get { return m_AssetBundleIndex; }
        }
        public AssetData(string name, short resType, int index)
        {
            m_AssetName = name;
            m_ResType = resType;
            m_Index = index;
        }

    }
}




