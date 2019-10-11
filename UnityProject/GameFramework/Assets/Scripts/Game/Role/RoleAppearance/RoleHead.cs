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
            base.SetAppearance(index);
            m_SkinnedMeshRenderer.sharedMesh = m_SourceMesh.GetMaleMeshByType(RoleMeshPart.Male_Head_All_Elements, index).sharedMesh;//prefeb.GetComponent<MeshFilter>().sharedMesh;
        }
    }
}
