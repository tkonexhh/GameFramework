using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public enum InventoryType
    {
        Weapon,
        Bow,
        Shield,
        Clouth,
        Food,
        Material,
        Key,
    }

    public class InventoryData : IDataClass
    {
        public List<InventoryEquipData> m_EquipItems;
        public List<InventoryItemData> m_Items;
        private Dictionary<int, InventoryItemData> m_ItemMap;
        public InventoryData()
        {
            SetDirtyRecorder(InventoryDataMgr.dataDirtyRecorder);
        }

        public override void InitWithEmptyData()
        {
            m_Items = new List<InventoryItemData>();
            m_EquipItems = new List<InventoryEquipData>();
        }

        public override void OnDataLoadFinish()
        {
            m_ItemMap = new Dictionary<int, InventoryItemData>();
            for (int i = 0; i < m_Items.Count; i++)
            {
                m_ItemMap.Add(m_Items[i].ID, m_Items[i]);
            }
        }

        public void AddItem(InventoryItemData item)
        {
            if (item is InventoryEquipData)
            {
                m_EquipItems.Add(item as InventoryEquipData);
            }
            else //if (item is InventoryItemData)
            {
                InventoryItemData itemData;
                if (m_ItemMap.TryGetValue(item.ID, out itemData))
                {
                    itemData.Num += item.Num;
                }
                else
                {
                    m_Items.Add(item);
                    m_ItemMap.Add(item.ID, item);
                }
            }

            SetDataDirty();
        }

        public void RemoveItem(InventoryItemData item)
        {
            if (item is InventoryEquipData)
            {
                m_EquipItems.Remove(item as InventoryEquipData);
            }
            else
            {
                InventoryItemData itemData;
                if (m_ItemMap.TryGetValue(item.ID, out itemData))
                {
                    m_ItemMap.Remove(item.ID);
                    m_Items.Remove(item);
                }
            }
        }

        public List<InventoryItemData> GetItemsByType(InventoryType type)
        {
            if (type == InventoryType.Weapon)
            {
                return m_EquipItems.ConvertAll(s => s as InventoryItemData);
            }
            else
            {
                return m_Items;
            }
        }
    }

    public class InventoryItemData
    {
        public int ID;
        public int Num;
        //private ItemSqliteData m_Config;
    }


    public class InventoryEquipData : InventoryItemData
    {
        public int Star;
    }


}
