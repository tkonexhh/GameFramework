using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

public class GamePlayMgr : TMonoSingleton<GamePlayMgr>
{
    public void Init()
    {
        UIMgr.S.OpenPanel("Resources/UI/Panel/InventoryPanel");
    }
}
