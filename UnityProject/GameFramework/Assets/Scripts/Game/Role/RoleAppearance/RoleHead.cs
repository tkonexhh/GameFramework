using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class RoleHead : RoleBaseAppearance
    {

        public override void Init()
        {
            m_ResLoader = ResLoader.Allocate("RoleHead");
            m_SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }
        public override void SetAppearance(int index)
        {
            string resPath = RoleAppearResPath.GetMaleHeadMeshNameByIndex(index);
            GameObject prefeb = m_ResLoader.LoadSync(resPath) as GameObject;
            Debug.LogError(prefeb);

            m_SkinnedMeshRenderer.sharedMesh = prefeb.GetComponent<MeshFilter>().mesh;
            // m_ObjAppearance = GameObject.Instantiate(prefeb, transform);
            // m_ObjAppearance.transform.Reset();
            // m_SkinnedMeshRenderer = m_ObjAppearance.AddComponent<SkinnedMeshRenderer>();
            // m_SkinnedMeshRenderer.rootBone = m_TargetBone;
        }
    }
}
