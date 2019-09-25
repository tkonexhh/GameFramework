using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;

namespace GameWish.Game
{
    public class PosRendererSorter : MonoBehaviour
    {
        [SerializeField]
        private Renderer[] m_Renders;
        [SerializeField]
        private int m_SortOrderBase = 5000;
        [SerializeField]
        private float m_OffsetY;
        [SerializeField]
        private bool m_RunOnce;

        private float m_Timer;
        private float m_DeltaCheckTime = 0.1f;

        void Awake()
        {
            if (m_Renders == null || m_Renders.Length == 0)
                m_Renders = gameObject.GetComponentsInChildren<Renderer>();
        }

        void LateUpdate()
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer < 0)
            {
                for (int i = 0; i < m_Renders.Length; i++)
                    m_Renders[i].sortingOrder = (int)(m_SortOrderBase - transform.position.y - m_OffsetY);
            }

            if (m_RunOnce)
                Destroy(this);
        }

        [ExecuteInEditMode]
        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position + m_OffsetY * Vector3.up, .25f);
        }
    }
}