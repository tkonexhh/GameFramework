using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ResLoader : IResLoader, IPoolAble, IPoolType
    {

        private List<IRes> m_ResLst = new List<IRes>();
        private string m_LoaderName;


        private static List<ResLoader> s_ActiveLoaderLst = new List<ResLoader>();

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

        private void LoadSync()
        {

        }

        public UnityEngine.Object LoadSync(string name)
        {
            Add2Load(name);
            LoadSync();
            return null;
        }

        public void LoadAsync()
        {

        }



        public bool Add2Load(string name)
        {
            return false;
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




