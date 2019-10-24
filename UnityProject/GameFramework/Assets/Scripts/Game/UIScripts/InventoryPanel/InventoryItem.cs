using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Main.Game
{

    public class InventoryItem : UListItemView
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtNum;
        [SerializeField] private Text m_TxtValue;
    }
}
