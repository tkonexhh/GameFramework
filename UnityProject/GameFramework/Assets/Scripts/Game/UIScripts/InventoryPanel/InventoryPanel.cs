using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public class InventoryPanel : AbstractPanel
    {
        [SerializeField] private List<InventoryNavIcon> m_NavIcons;
        [SerializeField] private InventoryItem m_InventoryItemPrefab;
        [SerializeField] private IUListView m_Scroll;
        [SerializeField] private InventoryRoleRoot m_RoleRoot;
        private InventoryType m_CurInventoryType;



        protected override void OnUIInit()
        {
            Debug.LogError("OnUIInit");
            GameObjectPoolMgr.S.AddPool("InventoryItem", m_InventoryItemPrefab.gameObject, 50, 20);
            for (int i = 0; i < m_NavIcons.Count; i++)
            {
                m_NavIcons[i].Init((InventoryType)i);
                int index = i;
                m_NavIcons[i].BtnBg.onClick.AddListener(() =>
                {
                    if (m_CurInventoryType == (InventoryType)index) return;
                    Showpage((InventoryType)index);
                });
            }
            m_Scroll.SetCellRenderer(OnCellRenderer);

            Showpage(InventoryType.Weapon);

        }

        private void Showpage(InventoryType type)
        {
            m_CurInventoryType = type;
            for (int i = 0; i < m_NavIcons.Count; i++)
            {
                if (m_NavIcons[i].Type == type)
                {
                    m_NavIcons[i].SetSelect(true);
                }
                else
                {
                    m_NavIcons[i].SetSelect(false);
                }
            }

            m_Scroll.SetDataCount(InventoryDataMgr.data.GetItemsByType(m_CurInventoryType).Count);
        }

        private void OnCellRenderer(Transform root, int index)
        {

        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryDataMgr.AddItem(100001, 1);
            }
        }


    }
}
