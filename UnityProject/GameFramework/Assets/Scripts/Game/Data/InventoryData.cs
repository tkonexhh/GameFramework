using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class InventoryData : IDataClass
    {
        public int id;
        public InventoryData()
        {
            SetDirtyRecorder(InventoryDataMgr.dataDirtyRecorder);
        }

        public override void InitWithEmptyData()
        {

        }

        public override void OnDataLoadFinish()
        {

        }
    }
}
