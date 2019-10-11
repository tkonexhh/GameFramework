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
            SkinnedMeshRenderer renderer = m_SourceMesh.GetRoleMeshByType(RoleMeshPart.Male_Head_All_Elements, index);
            SetNewRenderer(renderer);
        }
    }
}
