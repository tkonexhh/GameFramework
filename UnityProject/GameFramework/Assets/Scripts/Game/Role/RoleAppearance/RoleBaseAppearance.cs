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
        [SerializeField] protected SkinnedMeshRenderer m_SkinnedMeshRenderer;
        protected RoleAppearance m_Appearance;
        protected RoleSourceMesh m_SourceMesh;

        public virtual void Init(RoleAppearance role, RoleSourceMesh sourceMesh, RoleMeshPart part, int index = 0)
        {
            m_Appearance = role;
            m_SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            m_SourceMesh = sourceMesh;
            SetRoleMeshPart(part);
            SetAppearance(m_CurIndex);
        }

        private void SetRoleMeshPart(RoleMeshPart part)
        {
            m_MeshPart = part;
            m_MaxIndex = m_SourceMesh.GetCountByType(m_MeshPart);
        }


        public virtual void SetAppearance(int index)
        {
            m_CurIndex = index;
            SkinnedMeshRenderer renderer = m_SourceMesh.GetRoleMeshByType(m_MeshPart, index);
            SetNewRenderer(renderer);
        }

        protected void SetNewRenderer(SkinnedMeshRenderer renderer)
        {
            if (renderer == null)
                return;

            m_SkinnedMeshRenderer.localBounds = renderer.localBounds;
            Debug.LogError(m_SkinnedMeshRenderer.rootBone.name + "----" + renderer.rootBone.name);
            if (m_SkinnedMeshRenderer.rootBone.name != renderer.rootBone.name)
            {
                //m_SkinnedMeshRenderer.BakeMesh(renderer.sharedMesh);
                // for (int i = 0; i < m_SkinnedMeshRenderer.bones.Length; i++)
                // {
                //     Debug.LogError(m_SkinnedMeshRenderer.bones[i]);
                // }
                //m_SkinnedMeshRenderer.bones = renderer.bones;
                // m_SkinnedMeshRenderer.rootBone=re
                m_SkinnedMeshRenderer.rootBone = m_Appearance.Bones.GetTargetBones(renderer.rootBone.name);
            }
            m_SkinnedMeshRenderer.sharedMesh = renderer.sharedMesh;
        }


    }
}
