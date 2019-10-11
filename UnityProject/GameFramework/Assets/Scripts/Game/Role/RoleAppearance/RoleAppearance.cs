using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{
    public enum BodyPartEnum
    {
        Head,
        Eyebrows,
        FacialHair,
        Torso,
        Arm_Upper,
        Arm_Lower,
        Hand,
        // Arm_Upper_Right,
        // Arm_Upper_Left,
        // Arm_Lower_Right,
        // Arm_Lower_Left,
        // Hand_Right,
        // Hand_Left,
        Hips,
        Leg,
        // Leg_Right,
        // Leg_Left,
    }

    public class RoleAppearance : MonoBehaviour
    {
        [SerializeField] private RoleSourceMesh m_SourceMesh;

        [SerializeField] private RoleHead m_Head;
        [SerializeField] private RoleEyebrows m_Eyebrows;
        [SerializeField] private RoleFacialHair m_FacialHair;
        [SerializeField] private RoleTorso m_Torso;
        [SerializeField] private RoleArmUpperRight m_ArmUpperRight;
        [SerializeField] private RoleArmUpperLeft m_ArmUpperLeft;
        [SerializeField] private RoleArmLowerRight m_ArmLowerRight;
        [SerializeField] private RoleArmLowerLeft m_ArmLowerLeft;
        [SerializeField] private RoleHandRight m_HandRight;
        [SerializeField] private RoleHandLeft m_HandLeft;
        [SerializeField] private RoleHips m_Hips;
        [SerializeField] private RoleLegRight m_LegRight;
        [SerializeField] private RoleLegLeft m_LegLeft;


        private void Start()
        {
            m_Head.Init(m_SourceMesh);
            m_Eyebrows.Init(m_SourceMesh);
            m_FacialHair.Init(m_SourceMesh);
            m_Torso.Init(m_SourceMesh);
            m_ArmUpperRight.Init(m_SourceMesh);
            m_ArmUpperLeft.Init(m_SourceMesh);
            m_ArmLowerRight.Init(m_SourceMesh);
            m_ArmLowerLeft.Init(m_SourceMesh);
            m_HandRight.Init(m_SourceMesh);
            m_HandLeft.Init(m_SourceMesh);
            m_Hips.Init(m_SourceMesh);
            m_LegRight.Init(m_SourceMesh);
            m_LegLeft.Init(m_SourceMesh);
        }


        public void ChangeBodyPart(BodyPartEnum body, int index)
        {
            var party = GetRoleAppearanceByPart(body);
            for (int i = 0; i < party.Count; i++)
            {
                party[i].SetAppearance(index);
            }

        }

        private List<RoleBaseAppearance> GetRoleAppearanceByPart(BodyPartEnum body)
        {
            List<RoleBaseAppearance> appearances = new List<RoleBaseAppearance>();
            switch (body)
            {
                case BodyPartEnum.Head:
                    appearances.Add(m_Head);
                    break;
                case BodyPartEnum.Eyebrows:
                    appearances.Add(m_Eyebrows);
                    break;
                case BodyPartEnum.FacialHair:
                    appearances.Add(m_FacialHair);
                    break;
                case BodyPartEnum.Torso:
                    appearances.Add(m_Torso);
                    break;
                case BodyPartEnum.Arm_Upper:
                    appearances.Add(m_ArmUpperLeft);
                    appearances.Add(m_ArmUpperRight);
                    break;
                case BodyPartEnum.Arm_Lower:
                    appearances.Add(m_ArmLowerLeft);
                    appearances.Add(m_ArmLowerRight);
                    break;
                case BodyPartEnum.Hand:
                    appearances.Add(m_HandLeft);
                    appearances.Add(m_HandRight);
                    break;
                case BodyPartEnum.Hips:
                    appearances.Add(m_Hips);
                    break;
                case BodyPartEnum.Leg:
                    appearances.Add(m_LegLeft);
                    appearances.Add(m_LegRight);
                    break;
            }

            return appearances;
        }
    }
}
