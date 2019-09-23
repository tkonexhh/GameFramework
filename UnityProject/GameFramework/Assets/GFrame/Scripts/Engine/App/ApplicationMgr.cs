using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class ApplicationMgr : TMonoSingleton<ApplicationMgr>
    {
        private void Start()
        {
            AppConfig.S.InitAppConfig();
            ResMgr.S.InitResMgr();

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




