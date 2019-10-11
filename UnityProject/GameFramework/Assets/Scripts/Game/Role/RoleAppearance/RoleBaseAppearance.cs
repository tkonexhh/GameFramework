using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class RoleBaseAppearance : MonoBehaviour
    {
        [SerializeField]
        protected SkinnedMeshRenderer m_SkinnedMeshRenderer;
        [SerializeField]
        protected int m_CurIndex;
        protected RoleSourceMesh m_SourceMesh;

        public virtual void Init(RoleSourceMesh sourceMesh, int index = 0)
        {
            m_SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            m_SourceMesh = sourceMesh;
            SetAppearance(m_CurIndex);
        }


        public virtual void SetAppearance(int index)
        {
            m_CurIndex = index;
        }
    }
}
