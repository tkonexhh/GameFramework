using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{
    public class RoleLegLeft : RoleBaseAppearance
    {
        public override void SetAppearance(int index)
        {
            base.SetAppearance(index);
            SkinnedMeshRenderer renderer = m_SourceMesh.GetRoleMeshByType(RoleMeshPart.Male_12_Leg_Left, index);
            SetNewRenderer(renderer);
        }
    }
}
