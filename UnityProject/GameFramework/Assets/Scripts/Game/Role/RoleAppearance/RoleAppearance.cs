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
        [SerializeField] private RoleSourceMesh m_SourceMesh;

        [SerializeField] private RoleHead m_Head;
        [SerializeField] private RoleEyebrows m_Eyebrows;
        [SerializeField] private RoleFacialHair m_FacialHair;
        [SerializeField] private RoleTorso m_Torso;


        private void Start()
        {
            m_Head.Init(m_SourceMesh);
            m_Eyebrows.Init(m_SourceMesh);
            // m_FacialHair.Init();
            // m_Torso.Init();
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
