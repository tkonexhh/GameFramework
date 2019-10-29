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


        public static void AddItem(int id, int num)
        {
            InventoryItemData item = new InventoryItemData();
            item.ID = id;
            item.Num = num;
            data.AddItem(item);
            InventoryDataMgr.Save();
        }

        public static void AddEquip(int id)
        {
            InventoryEquipData equipData = new InventoryEquipData();
            equipData.ID = id;
            equipData.Num = 1;
            data.AddItem(equipData);
            InventoryDataMgr.Save();
        }

        public static void RemoveEquip(InventoryEquipData equipData)
        {
            data.RemoveItem(equipData);
        }

    }
}
