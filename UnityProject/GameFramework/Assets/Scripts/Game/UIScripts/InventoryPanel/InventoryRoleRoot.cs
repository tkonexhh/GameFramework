using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class InventoryRoleRoot : MonoBehaviour, IEventReceiver
    {
        [SerializeField] RoleAppearance m_Role;
        [SerializeField] InventoryEquipRoot m_Equip;


        public void Init(InventoryPanel panel)
        {
            EventSystem.S.Register(EventID.OnRoleEquip, OnEventHandler);
        }

        public void OnEventHandler(int key, params object[] args)
        {
            switch (key)
            {
                case (int)EventID.OnRoleEquip:
                    break;
            }
        }

    }
}
