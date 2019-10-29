using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using UnityEngine.EventSystems;

namespace Main.Game
{

    public class InventoryItem : UListItemView, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtNum;
        [SerializeField] private Text m_TxtValue;

        private InventoryItemData m_Data;
        private InventoryRoot m_InventoryRoot;
        private RectTransform m_RT;
        private Vector3 m_DragOffset;

        public InventoryItemData Data
        {
            get { return m_Data; }
        }

        public void SetData(InventoryRoot inventoryRoot, InventoryItemData data)
        {
            if (m_InventoryRoot == null)
            {
                m_InventoryRoot = inventoryRoot;
                m_RT = m_InventoryRoot.ScrollView.transform as RectTransform;
            }

            m_Data = data;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (m_Data is InventoryEquipData)
            {
                m_TxtNum.gameObject.SetEnable(false);
            }
            else
            {
                m_TxtNum.gameObject.SetEnable(true);
                m_TxtNum.text = string.Format("x {0}", m_Data.Num);
            }
        }

        public void ShowUsed()
        {

        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            m_InventoryRoot.EnableImgDrag(true);
            Vector3 worldPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(m_RT, eventData.position, eventData.pressEventCamera, out worldPos);
            m_DragOffset = transform.position - worldPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 nowPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(m_RT, eventData.position, eventData.pressEventCamera, out nowPos);
            m_InventoryRoot.ImgDrag.transform.position = nowPos + m_DragOffset;
            m_InventoryRoot.ImgDrag.transform.SetLocalZ(0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.LogError("OnEndDrag");
            m_InventoryRoot.EnableImgDrag(false);
        }
    }
}
