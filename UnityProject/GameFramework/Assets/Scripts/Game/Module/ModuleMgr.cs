using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class ModuleMgr : AbstractActor
    {

        protected override void OnActorAwake()
        {
            AddComponent<InputModule>();
            AddComponent<TableModule>();
            AddComponent<UIDataModule>();
        }


    }



}




