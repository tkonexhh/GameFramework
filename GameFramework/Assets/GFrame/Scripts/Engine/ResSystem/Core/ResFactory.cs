using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ResFactory
    {
        public delegate IRes ResCreator(string name);

        public interface IResCreatorWrap
        {
            bool CheckResType(string name);
            IRes CreateRes(string name);
        }

        class ResCreatorWrap : IResCreatorWrap
        {
            private string m_Key;
            private ResCreator m_Creator;

            public ResCreatorWrap(string key, ResCreator creator)
            {
                m_Key = key;
                m_Creator = creator;
            }

            public bool CheckResType(string name)
            {
                return name.StartsWith(m_Key);
            }
            public IRes CreateRes(string name)
            {
                return m_Creator(name);
            }
        }

        class AssetResCreatorWrap : IResCreatorWrap
        {
            public bool CheckResType(string name)
            {
                AssetData data = AssetDataTable.S.GetAssetData(name);
                return data != null;
            }
            public IRes CreateRes(string name)
            {
                AssetData data = AssetDataTable.S.GetAssetData(name);
                switch (data.assetType)
                {
                    case eResType.kAssetBundle:
                        return AssetBundleRes.Allocate(name);
                    case eResType.kABAsset:
                        return AssetRes.Allocate(name);
                    default:
                        return null;
                }
            }
        }

        private static AssetResCreatorWrap s_AssetResCreatorWrap;

        static ResFactory()
        {
            Log.i("#Init[ResFactory]");
            s_AssetResCreatorWrap = new AssetResCreatorWrap();
        }

        public static IRes Create(string name)
        {
            if (s_AssetResCreatorWrap.CheckResType(name))
            {
                return s_AssetResCreatorWrap.CreateRes(name);
            }
            return null;
        }
    }
}




