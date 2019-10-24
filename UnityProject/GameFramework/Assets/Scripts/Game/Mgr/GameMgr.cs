using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{


    public class GameMgr : TSingleton<GameMgr>
    {
        public void Init()
        {
            GameDataMgr.S.Init();
            SqliteMgr.S.Init();
            GamePlayMgr.S.Init();
        }
    }
}
