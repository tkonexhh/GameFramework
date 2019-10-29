using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using UnityEngine.EventSystems;

namespace Main.Game
{

    public class InventoryEquipRootItem : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Image m_ImgBg;
        //[SerializeField] private GameObject m_ObjEquip;


        private InventoryEquipData m_Data;
        private ResLoader m_Loader;

        private void Awake()
        {
            if (m_ImgBg == null)
            {
                m_ImgBg = GetComponent<Image>();
            }
        }
        public void SetEquip(InventoryEquipData data)
        {
            m_Data = data;
            if (m_Loader == null)
            {
                m_Loader = ResLoader.Allocate();
            }
            Texture2D texture = m_Loader.LoadSync("ItemIcon_100001") as Texture2D;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            m_ImgBg.sprite = sprite;

            GFrame.EventSystem.S.Send(EventID.OnRoleEquip);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.LogError("OnDrop");
            GameObject obj = eventData.pointerDrag;
            var inventoryItem = obj.GetComponent<InventoryItem>();
            if (inventoryItem == null)
                return;

            if (inventoryItem.Data is InventoryEquipData)
            {
                InventoryMgr.S.Equip(inventoryItem, this);
            }

        }
    }
}
