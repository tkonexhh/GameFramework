using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ResLoader : IResLoader, IPoolAble, IPoolType
    {
        private static List<ResLoader> s_ActiveLoaderLst = new List<ResLoader>();

        private List<IRes> m_ResLst = new List<IRes>();
        private string m_LoaderName;


        public string loaderName
        {
            get { return m_LoaderName; }
        }

        public static ResLoader Allocate(string name = null)
        {
            ResLoader loader = ObjectPool<ResLoader>.S.Allocate();
            loader.m_LoaderName = name;
            s_ActiveLoaderLst.Add(loader);
            return loader;
        }

        // private void LoadSync()
        // {

        // }

        public UnityEngine.Object LoadSync(string name)
        {
            Add2Load(name);
            //LoadSync();

            IRes res = ResMgr.S.GetRes(name);
            if (res == null)
            {
                Log.e("#Failed to Load Res:" + name);
                return null;
            }
            if (res.LoadSync())
            {
                return res.asset;
            }

            return null;

        }

        public void LoadAsync()
        {

        }


        public bool Add2Load(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.e("#Res Name Is Null");
                return false;
            }

            IRes res = FindResInArray(name);
            if (res != null)
            {
                //已经加载完毕了
                return true;
            }

            res = ResMgr.S.GetRes(name);
            if (res == null)
            {
                return false;
            }

            AddResToArray(res);

            return false;
        }

        private IRes FindResInArray(string name)
        {
            for (int i = m_ResLst.Count - 1; i >= 0; --i)
            {
                if (m_ResLst[i].name.Equals(name))
                {
                    return m_ResLst[i];
                }
            }
            return null;
        }

        private void AddResToArray(IRes res)
        {
            m_ResLst.Add(res);
        }

        public void ReleaseAllRes()
        {

        }

        public void OnCacheReset()
        {

        }

        public void Recycle2Cache()
        {

        }
    }
}




