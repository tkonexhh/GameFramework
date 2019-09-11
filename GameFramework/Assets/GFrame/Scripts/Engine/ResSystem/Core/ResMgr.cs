using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ResMgr : TMonoSingleton<ResMgr>
    {

        private Dictionary<string, IRes> m_ResMap = new Dictionary<string, IRes>();
        private List<IRes> m_ResList = new List<IRes>();


        public override void OnSingletonInit()
        {

        }
    }
}




