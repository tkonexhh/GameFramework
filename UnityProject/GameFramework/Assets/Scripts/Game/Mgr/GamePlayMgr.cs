using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class GamePlayMgr : TMonoSingleton<GamePlayMgr>
    {
        public override void OnSingletonInit()
        {
            gameObject.AddMissingComponent<ModuleMgr>();
        }


        public void Init()
        {
            // UIMgr.S.OpenPanel("Resources/UI/Panel/InventoryPanel");
            UIMgr.S.OpenPanel(UIID.InventoryPanel);
        }
    }
}
