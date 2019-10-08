using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class RoleBaseAppearance : MonoBehaviour
    {
        protected GameObject m_ObjAppearance;
        protected ResLoader m_ResLoader;
        protected Transform m_TargetBone;
        [SerializeField]
        protected SkinnedMeshRenderer m_SkinnedMeshRenderer;

        public virtual void Init()
        {
            m_ResLoader = ResLoader.Allocate("RoleAppearance");
            m_SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        // public void SetTargetBone(Transform bone)
        // {
        //     m_TargetBone = bone;
        // }

        public virtual void SetAppearance(int index)
        {

        }
    }
}
