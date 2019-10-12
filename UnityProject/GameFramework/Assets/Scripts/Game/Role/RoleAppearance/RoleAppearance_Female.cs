using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{


    public class RoleAppearance_Female : RoleAppearance
    {

        protected override void Init()
        {
            m_Head.Init(this, m_SourceMesh, RoleMeshPart.Female_Head_All_Elements);
            m_Eyebrows.Init(this, m_SourceMesh, RoleMeshPart.Female_01_Eyebrows);
            m_Torso.Init(this, m_SourceMesh, RoleMeshPart.Female_03_Torso);
            m_ArmUpperRight.Init(this, m_SourceMesh, RoleMeshPart.Female_04_Arm_Upper_Right);
            m_ArmUpperLeft.Init(this, m_SourceMesh, RoleMeshPart.Female_05_Arm_Upper_Left);
            m_ArmLowerRight.Init(this, m_SourceMesh, RoleMeshPart.Female_06_Arm_Lower_Right);
            m_ArmLowerLeft.Init(this, m_SourceMesh, RoleMeshPart.Female_07_Arm_Lower_Left);
            m_HandRight.Init(this, m_SourceMesh, RoleMeshPart.Female_08_Hand_Right);
            m_HandLeft.Init(this, m_SourceMesh, RoleMeshPart.Female_09_Hand_Left);
            m_Hips.Init(this, m_SourceMesh, RoleMeshPart.Female_10_Hips);
            m_LegRight.Init(this, m_SourceMesh, RoleMeshPart.Female_11_Leg_Right);
            m_LegLeft.Init(this, m_SourceMesh, RoleMeshPart.Female_12_Leg_Left);
        }

    }
}
