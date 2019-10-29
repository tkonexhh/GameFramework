using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Game
{
    public class InventoryNavIcon : MonoBehaviour
    {
        [SerializeField] private InventoryType m_Type;
        [SerializeField] private Text m_TxtTitle;
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Transform m_PointRoot;
        [SerializeField] private Button m_BtnBg;

        public InventoryType Type
        {
            get { return m_Type; }
        }
        public Button BtnBg
        {
            get { return m_BtnBg; }
        }



        public void Init(InventoryType type)
        {
            m_Type = type;
            m_PointRoot.gameObject.SetActive(false);
        }

        public void SetSelect(bool select)
        {
            if (select)
            {
                m_TxtTitle.gameObject.SetActive(true);
            }
            else
            {
                m_TxtTitle.gameObject.SetActive(false);
            }
        }
    }
}
