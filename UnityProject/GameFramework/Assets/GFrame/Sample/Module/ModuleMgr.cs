using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Sample
{
    public class ModuleMgr : AbstractActor
    {

        private void Start()
        {
            AddComponent<InputModule>();
        }

        // private void Start()
        // {

        //     MyModuleMgr.S.Init();
        // }

        // public class MyModuleMgr : AbstractActor
        // {
        //     public static MyModuleMgr m_MyModuleMgr;
        //     public static MyModuleMgr S
        //     {
        //         get
        //         {
        //             if (m_MyModuleMgr == null)
        //             {
        //                 m_MyModuleMgr = new MyModuleMgr();
        //             }
        //             return m_MyModuleMgr;
        //         }
        //     }
        //     public void Init()
        //     {
        //         m_MyModuleMgr.AddComponent<InputModule>();
        //     }
        // }
    }



}




