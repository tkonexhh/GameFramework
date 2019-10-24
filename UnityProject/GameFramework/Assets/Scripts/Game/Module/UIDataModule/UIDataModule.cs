using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class UIDataModule : AbstractModule
    {
        protected override void OnComAwake()
        {
            //UIDataTable.Add
            RegisterPanel();
        }

        private void RegisterPanel()
        {
            Debug.LogError("RegisterPanel");
            UIDataTable.SetABMode(false);

            UIDataTable.AddPanelData(UIID.InventoryPanel, "Resources/UI/Panel/InventoryPanel");
        }
    }
}