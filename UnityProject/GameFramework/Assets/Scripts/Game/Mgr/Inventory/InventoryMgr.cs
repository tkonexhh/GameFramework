using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class InventoryMgr : TMonoSingleton<InventoryMgr>
    {

        public List<InventoryItemData> GetItemsByType(InventoryType type)
        {
            return InventoryDataMgr.data.GetItemsByType(type);
        }
        public void Equip(InventoryItem inventoryItem, InventoryEquipRootItem equipRootItem)
        {
            //刷新装备栏
            equipRootItem.SetEquip(inventoryItem.Data as InventoryEquipData);
            //inventoryItem.Set
            //inventoryItem.gameObject.SetActive(false);
            //刷新道具栏位
            //InventoryDataMgr.RemoveEquip(inventoryItem.Data as InventoryEquipData);

        }
    }
}
