using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class NetImgRes : AbstractRes
    {
        public const string PREFIX_KEY = "NetImage:";
        private string m_Url;
        private string m_HashCode;


        public static NetImgRes Allocate(string name)
        {
            NetImgRes res = ObjectPool<NetImgRes>.S.Allocate();
            if (res != null)
            {
                res.name = name;
            }
            return res;
        }

        public override bool LoadSync()//同步加载
        {

            if (string.IsNullOrEmpty(m_Name))
            {
                return false;
            }


            m_Asset = asset;
            if (m_Asset != null)
            {
                return true;
            }
            return false;
        }

        public override void LoadAsync()//异步加载
        {

        }

        public override void Recycle2Cache()
        {
            ObjectPool<NetImgRes>.S.Recycle(this);
        }

        public override void OnCacheReset()
        {

        }
    }
}




