using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Main.Game
{

    public class InventoryPanel : AbstractPanel
    {
        [SerializeField] private Button m_BtnClose;
        [SerializeField] private InventoryRoot m_InventoryRoot;
        [SerializeField] private InventoryRoleRoot m_RoleRoot;


        protected override void OnUIInit()
        {
            m_BtnClose.onClick.AddListener(OnClickClose);
            m_InventoryRoot.Init(this);
            m_RoleRoot.Init(this);

        }

        private void OnClickClose()
        {
            CloseSelfPanel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryDataMgr.AddEquip(200001);
                InventoryDataMgr.AddItem(100001, 1);
            }
        }


    }
}
