using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class InventoryData : IDataClass
    {
        public List<ItemData> m_Items;
        private Dictionary<int, ItemData> m_ItemMap;
        public InventoryData()
        {
            SetDirtyRecorder(InventoryDataMgr.dataDirtyRecorder);
        }

        public override void InitWithEmptyData()
        {
            m_Items = new List<ItemData>();
        }

        public override void OnDataLoadFinish()
        {
            m_ItemMap = new Dictionary<int, ItemData>();
            for (int i = 0; i < m_Items.Count; i++)
            {
                m_ItemMap.Add(m_Items[i].ID, m_Items[i]);
            }
        }

        public void AddItem(ItemData item)
        {
            ItemData itemData;
            if (m_ItemMap.TryGetValue(item.ID, out itemData))
            {
                itemData.Num += item.Num;
            }
            else
            {
                m_Items.Add(item);
                m_ItemMap.Add(item.ID, item);
            }
            SetDataDirty();
        }

        public List<ItemData> GetItemsByType(InventoryType type)
        {
            //List<ItemData> lst = new List<ItemData>();

            return m_Items;
        }
    }

    public class ItemData
    {
        public int ID;
        public int Num;
        private ItemSqliteData m_Config;
    }


}
