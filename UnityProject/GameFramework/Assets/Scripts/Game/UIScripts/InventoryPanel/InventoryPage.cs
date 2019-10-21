using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CircularScrollView;

namespace Main.Game
{

    public class InventoryPage : MonoBehaviour
    {
        [SerializeField] UICircularScrollView m_ScrollView;

        private void Awake()
        {
            m_ScrollView.Init(CellRender);
            m_ScrollView.ShowList(50);
        }

        private void CellRender(GameObject gameObject, int index)
        {

        }

    }
}
