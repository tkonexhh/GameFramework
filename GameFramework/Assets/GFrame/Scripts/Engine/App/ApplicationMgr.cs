﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ApplicationMgr : TMonoSingleton<ApplicationMgr>
    {
        private void Start()
        {
            AppConfig.S.InitAppConfig();


            StartApp();
        }

        void StartApp()
        {
            StartGame();
        }

        void StartGame()
        {

        }
    }
}




