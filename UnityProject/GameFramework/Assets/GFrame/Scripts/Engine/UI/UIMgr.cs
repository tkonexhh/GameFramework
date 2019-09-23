﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class UIMgr : TMonoSingleton<UIMgr>
    {
        private UIRoot m_UIRoot;
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

        private UIRoot LoadUIRoot()
        {
            return null;
        }
    }
}



