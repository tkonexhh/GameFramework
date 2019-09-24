using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class ModuleMgr : AbstractActor
    {

        private void Start()
        {
            AddComponent<InputModule>();
            AddComponent<TableModule>();
        }


    }



}




