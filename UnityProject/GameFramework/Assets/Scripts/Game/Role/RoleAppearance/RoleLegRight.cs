using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{
    public class RoleLegRight : RoleBaseAppearance
    {
        public override void SetAppearance(int index)
        {
            base.SetAppearance(index);
            SkinnedMeshRenderer renderer = m_SourceMesh.GetRoleMeshByType(RoleMeshPart.Male_11_Leg_Right, index);
            SetNewRenderer(renderer);
        }
    }
}
