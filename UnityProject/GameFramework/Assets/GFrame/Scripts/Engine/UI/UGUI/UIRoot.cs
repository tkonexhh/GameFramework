using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class UIRoot : MonoBehaviour
    {
        [SerializeField] Transform m_PanelRoot;
        [SerializeField] Transform m_HideRoot;
        [SerializeField] Camera m_Camera;
        [SerializeField] Canvas m_RootCanvas;

        public Transform panelRoot
        {
            get { return m_PanelRoot; }
        }

        public Transform hideRoot
        {
            get { return m_HideRoot; }
        }

        public Camera uiCamera
        {
            get { return m_Camera; }
        }

        public Canvas rootCanvas
        {
            get { return m_RootCanvas; }
        }
    }
}




