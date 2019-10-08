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
    }

    public class RoleAppearance : MonoBehaviour
    {

        [SerializeField] private RoleHead m_Head;
        [SerializeField] private RoleEyebrows m_Eyebrows;
        [SerializeField] private RoleFacialHair m_FacialHair;
        [SerializeField] private RoleTorso m_Torso;


        [SerializeField] private Transform m_BoneNeck;
        [SerializeField] private Transform m_BoneEyebrows;
        [SerializeField] private Transform m_BoneFcialHair;
        [SerializeField] private Transform m_BoneTorso;

        private void Start()
        {
            m_Head.Init();
            m_Eyebrows.Init();
            m_FacialHair.Init();
            m_Torso.Init();
            // m_Head.SetTargetBone(m_BoneNeck);
            // m_Eyebrows.SetTargetBone(m_BoneEyebrows);
            // m_FacialHair.SetTargetBone(m_BoneFcialHair);
            // m_Torso.SetTargetBone(m_BoneTorso);
        }


        public void ChangeBodyPart(BodyPartEnum body, int index)
        {
            var party = GetRoleAppearanceByPart(body);
            party.SetAppearance(index);
        }

        private RoleBaseAppearance GetRoleAppearanceByPart(BodyPartEnum body)
        {
            switch (body)
            {
                case BodyPartEnum.Head:
                    return m_Head;
                case BodyPartEnum.Eyebrows:
                    return m_Eyebrows;
                case BodyPartEnum.FacialHair:
                    return m_FacialHair;
                case BodyPartEnum.Torso:
                    return m_Torso;
            }

            return null;
        }
    }
}
