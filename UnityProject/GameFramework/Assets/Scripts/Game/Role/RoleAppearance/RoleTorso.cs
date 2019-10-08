using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{

    public class RoleTorso : RoleBaseAppearance
    {
        public override void SetAppearance(int index)
        {
            string resPath = RoleAppearResPath.GetMaleTorsoMeshNameByIndex(index);
            GameObject prefeb = m_ResLoader.LoadSync(resPath) as GameObject;
            m_SkinnedMeshRenderer.sharedMesh = prefeb.GetComponent<MeshFilter>().sharedMesh;
        }
    }
}
