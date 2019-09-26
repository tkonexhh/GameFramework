using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class UIMgr : TMonoSingleton<UIMgr>
    {
        private const string UIROOTPATH = "Resources/UI/UIRoot";

        private UIRoot m_UIRoot;
        public UIRoot uiRoot
        {
            get
            {
                return m_UIRoot;
            }
        }
        public override void OnSingletonInit()
        {
            if (m_UIRoot == null)
            {
                UIRoot root = GameObject.FindObjectOfType<UIRoot>();
                if (root == null)
                {
                    root = LoadUIRoot();
                }

                m_UIRoot = root;
                if (m_UIRoot == null)
                    Log.e("Error:UIRoot Is Null.");
            }
        }

        public void Init() { }

        private UIRoot LoadUIRoot()
        {
            ResLoader loader = ResLoader.Allocate("UIMgr");
            // loader.Add2Load("Resources/UI/UIRoot");
            // loader.LoadSync();

            Object uiRootObj = loader.LoadSync("Resources/UI/UIRoot");
            if (uiRootObj == null)
            {
                Log.e("Failed To Load UIRoot at" + UIROOTPATH);
                return null;
            }
            GameObject uiRootGo = GameObject.Instantiate(uiRootObj as GameObject);
            return uiRootGo.GetComponent<UIRoot>();
        }
    }
}




