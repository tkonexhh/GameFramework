using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class RoleBaseAppearance : MonoBehaviour
    {

        [SerializeField] protected int m_CurIndex;
        protected RoleMeshPart m_MeshPart;
        protected int m_MaxIndex;
        protected SkinnedMeshRenderer m_SkinnedMeshRenderer;

        protected RoleSourceMesh m_SourceMesh;

        public virtual void Init(RoleSourceMesh sourceMesh, int index = 0)
        {
            m_SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            m_SourceMesh = sourceMesh;
            SetAppearance(m_CurIndex);
        }

        public void SetRoleMeshPart(RoleMeshPart part)
        {
            m_MeshPart = part;
            m_MaxIndex = m_SourceMesh.GetCountByType(m_MeshPart);
        }


        public virtual void SetAppearance(int index)
        {
            m_CurIndex = index;
            // SkinnedMeshRenderer renderer = m_SourceMesh.GetRoleMeshByType(m_MeshPart, index);
            // SetNewRenderer(renderer);
        }

        protected void SetNewRenderer(SkinnedMeshRenderer renderer)
        {
            m_SkinnedMeshRenderer.localBounds = renderer.localBounds;
            m_SkinnedMeshRenderer.sharedMesh = renderer.sharedMesh;
        }


    }
}
