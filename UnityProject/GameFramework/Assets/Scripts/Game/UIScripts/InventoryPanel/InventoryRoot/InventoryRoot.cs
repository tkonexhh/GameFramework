using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Main.Game
{

    public class InventoryRoot : MonoBehaviour
    {
        [SerializeField] private List<InventoryNavIcon> m_NavIcons;
        [SerializeField] private IUListView m_Scroll;
        [SerializeField] private Image m_ImgDrag;

        public IUListView ScrollView
        {
            get { return m_Scroll; }
        }
        public Image ImgDrag
        {
            get { return m_ImgDrag; }
        }
        private InventoryPanel m_Panel;
        private InventoryType m_CurInventoryType;
        private List<InventoryItemData> m_SelectItems;

        public void Init(InventoryPanel panel)
        {
            m_Panel = panel;

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
            m_SelectItems = InventoryMgr.S.GetItemsByType(m_CurInventoryType);
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

            m_Scroll.SetDataCount(m_SelectItems.Count);
        }

        private void OnCellRenderer(Transform root, int index)
        {
            root.GetComponent<InventoryItem>().SetData(this, m_SelectItems[index]);
        }

        #region ImgDrag
        public void EnableImgDrag(bool enable)
        {
            // if (!enable)
            // {
            //     m_ImgDrag.transform.position = Vector3.one * 5000;
            // }

            m_ImgDrag.gameObject.SetActive(enable);
        }
        #endregion


    }
}
