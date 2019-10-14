using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class GameDataMgr : TSingleton<GameDataMgr>
    {
        public override void OnSingletonInit()
        {
            PlayerDataMgr playerData = new PlayerDataMgr();
            InventoryDataMgr inventoryData = new InventoryDataMgr();
        }

        public void Init()
        {
            PlayerDataMgr.Save();
            InventoryDataMgr.Save();
        }
    }



    public class PlayerDataMgr : DataClassHandler<GameData>
    {
        public static DataDirtyRecorder dataDirtyRecorder = new DataDirtyRecorder();

        public PlayerDataMgr()
        {
            Load();
        }

    }

    public class InventoryDataMgr : DataClassHandler<InventoryData>
    {
        public static DataDirtyRecorder dataDirtyRecorder = new DataDirtyRecorder();

        public InventoryDataMgr()
        {
            Load();
        }

    }
}
