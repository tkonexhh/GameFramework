using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class ApplicationMgr : TMonoSingleton<ApplicationMgr>
    {
        private void Start()
        {
            AppConfig.S.InitAppConfig();
            ResMgr.S.InitResMgr();
            UIMgr.S.Init();
            StartGame();

        }

        void StartGame()
        {
            GameMgr.S.Init();
            //StartGame();
        }


    }
}




