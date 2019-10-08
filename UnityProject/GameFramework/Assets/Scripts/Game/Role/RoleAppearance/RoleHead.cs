using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public class RoleHead : RoleBaseAppearance
    {

        public override void SetAppearance(int index)
        {
            string resPath = RoleAppearResPath.GetMaleHeadMeshNameByIndex(index);
            GameObject prefeb = m_ResLoader.LoadSync(resPath) as GameObject;
            m_SkinnedMeshRenderer.sharedMesh = prefeb.GetComponent<MeshFilter>().sharedMesh;
        }
    }
}
