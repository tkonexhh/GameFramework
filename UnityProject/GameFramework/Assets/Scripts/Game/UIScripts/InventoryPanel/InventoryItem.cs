using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Game
{

    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtNum;
        [SerializeField] private Text m_TxtValue;
    }
}
