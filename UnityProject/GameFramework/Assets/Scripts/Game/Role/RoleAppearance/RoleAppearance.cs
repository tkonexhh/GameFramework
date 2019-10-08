using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{
    public enum BodyPartEnum
    {
        Head,
        Eyebrows,
        FacialHair
    }

    public class RoleAppearance : MonoBehaviour
    {

        [SerializeField] private RoleHead m_Head;
        [SerializeField] private RoleEyebrows m_Eyebrows;
        [SerializeField] private RoleFacialHair m_FacialHair;

        [SerializeField] private Transform m_BoneNeck;
        [SerializeField] private Transform m_BoneEyebrows;
        // public Transform BoneNeck
        // {
        //     get { return m_BoneNeck; }
        // }

        private void Start()
        {
            m_Head.Init();
            m_Eyebrows.Init();
            m_Head.SetTargetBone(m_BoneNeck);
            m_Eyebrows.SetTargetBone(m_BoneEyebrows);
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
            }

            return null;
        }
    }
}
