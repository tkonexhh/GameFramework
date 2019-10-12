using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{
    public enum BodyPartEnum
    {
        Face,
        Hair,
        Eyebrows,
        FacialHair,
        Torso,
        Arm_Upper,
        Arm_Lower,
        Hand,
        Hips,
        Leg,

        ////Attachment
        ShoulderAttachment,
        ElbowAttachment,
        KneeAttachment,
        HipsAttachment,
        Ear,
    }

    public class RoleAppearance : MonoBehaviour
    {
        [SerializeField] protected RoleSourceMesh m_SourceMesh;
        [SerializeField] protected RoleBones m_Bones;
        public RoleBones Bones
        {
            get { return m_Bones; }
        }

        [SerializeField] protected RoleFace m_Head;
        [SerializeField] protected RoleHair m_Hair;
        [SerializeField] protected RoleEyebrows m_Eyebrows;
        [SerializeField] protected RoleFacialHair m_FacialHair;
        [SerializeField] protected RoleTorso m_Torso;
        [SerializeField] protected RoleArmUpperRight m_ArmUpperRight;
        [SerializeField] protected RoleArmUpperLeft m_ArmUpperLeft;
        [SerializeField] protected RoleArmLowerRight m_ArmLowerRight;
        [SerializeField] protected RoleArmLowerLeft m_ArmLowerLeft;
        [SerializeField] protected RoleHandRight m_HandRight;
        [SerializeField] protected RoleHandLeft m_HandLeft;
        [SerializeField] protected RoleHips m_Hips;
        [SerializeField] protected RoleLegRight m_LegRight;
        [SerializeField] protected RoleLegLeft m_LegLeft;

        [SerializeField] protected RoleShoulderAttachmentRight m_ShoulderAttachmentRight;
        [SerializeField] protected RoleShoulderAttachmentLeft m_ShoulderAttachmentLeft;
        [SerializeField] protected RoleElbowAttachmentRight m_ElbowAttachmentRight;
        [SerializeField] protected RoleElbowAttachmentLeft m_ElbowAttachmentLeft;
        [SerializeField] protected RoleKneeAttachmentRight m_KneeAttachmentRight;
        [SerializeField] protected RoleKneeAttachmentLeft m_KneeAttachmentLeft;
        [SerializeField] protected RoleHipsAttachment m_HipsAttachment;
        [SerializeField] protected RoleEar m_Ear;

        private void Start()
        {
            m_Bones = gameObject.AddMissingComponent<RoleBones>();
            m_Head = GetComponentInChildren<RoleFace>();
            m_Hair = GetComponentInChildren<RoleHair>();
            m_Eyebrows = GetComponentInChildren<RoleEyebrows>();
            m_Torso = GetComponentInChildren<RoleTorso>();
            m_ArmUpperRight = GetComponentInChildren<RoleArmUpperRight>();
            m_ArmUpperLeft = GetComponentInChildren<RoleArmUpperLeft>();
            m_ArmLowerRight = GetComponentInChildren<RoleArmLowerRight>();
            m_ArmLowerLeft = GetComponentInChildren<RoleArmLowerLeft>();
            m_HandRight = GetComponentInChildren<RoleHandRight>();
            m_HandLeft = GetComponentInChildren<RoleHandLeft>();
            m_Hips = GetComponentInChildren<RoleHips>();
            m_LegRight = GetComponentInChildren<RoleLegRight>();
            m_LegLeft = GetComponentInChildren<RoleLegLeft>();
            m_ShoulderAttachmentRight = GetComponentInChildren<RoleShoulderAttachmentRight>();
            m_ShoulderAttachmentLeft = GetComponentInChildren<RoleShoulderAttachmentLeft>();
            m_ElbowAttachmentRight = GetComponentInChildren<RoleElbowAttachmentRight>();
            m_ElbowAttachmentLeft = GetComponentInChildren<RoleElbowAttachmentLeft>();
            m_KneeAttachmentRight = GetComponentInChildren<RoleKneeAttachmentRight>();
            m_KneeAttachmentLeft = GetComponentInChildren<RoleKneeAttachmentLeft>();
            m_HipsAttachment = GetComponentInChildren<RoleHipsAttachment>();
            m_Ear = GetComponentInChildren<RoleEar>();

            m_Hair.Init(this, m_SourceMesh, RoleMeshPart.All_01_Hair);
            m_ShoulderAttachmentRight.Init(this, m_SourceMesh, RoleMeshPart.All_05_Shoulder_Attachment_Right);
            m_ShoulderAttachmentLeft.Init(this, m_SourceMesh, RoleMeshPart.All_06_Shoulder_Attachment_Left);
            m_ElbowAttachmentRight.Init(this, m_SourceMesh, RoleMeshPart.All_07_Elbow_Attachment_Right);
            m_ElbowAttachmentLeft.Init(this, m_SourceMesh, RoleMeshPart.All_08_Elbow_Attachment_Left);
            m_HipsAttachment.Init(this, m_SourceMesh, RoleMeshPart.All_09_Hips_Attachment);
            m_KneeAttachmentRight.Init(this, m_SourceMesh, RoleMeshPart.All_10_Knee_Attachement_Right);
            m_KneeAttachmentLeft.Init(this, m_SourceMesh, RoleMeshPart.All_11_Knee_Attachement_Left);
            m_Ear.Init(this, m_SourceMesh, RoleMeshPart.All_12_Extra);

            Init();
        }

        protected virtual void Init()
        {

        }

        public void ChangeBodyPart(BodyPartEnum body, int index)
        {
            var party = GetRoleAppearanceByPart(body);
            if (party.Count > 0)
            {
                for (int i = 0; i < party.Count; i++)
                {
                    if (party[i] != null)
                        party[i].SetAppearance(index);
                }
            }
        }

        private List<RoleBaseAppearance> GetRoleAppearanceByPart(BodyPartEnum body)
        {
            List<RoleBaseAppearance> appearances = new List<RoleBaseAppearance>();
            switch (body)
            {
                case BodyPartEnum.Face:
                    appearances.Add(m_Head);
                    break;
                case BodyPartEnum.Hair:
                    appearances.Add(m_Hair);
                    break;
                case BodyPartEnum.Eyebrows:
                    appearances.Add(m_Eyebrows);
                    break;
                case BodyPartEnum.FacialHair:
                    if (m_FacialHair != null)
                    {
                        appearances.Add(m_FacialHair);
                    }
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

                case BodyPartEnum.ShoulderAttachment:
                    appearances.Add(m_ShoulderAttachmentLeft);
                    appearances.Add(m_ShoulderAttachmentRight);
                    break;
                case BodyPartEnum.ElbowAttachment:
                    appearances.Add(m_ElbowAttachmentLeft);
                    appearances.Add(m_ElbowAttachmentRight);
                    break;
                case BodyPartEnum.KneeAttachment:
                    appearances.Add(m_KneeAttachmentLeft);
                    appearances.Add(m_KneeAttachmentRight);
                    break;
                case BodyPartEnum.HipsAttachment:
                    appearances.Add(m_HipsAttachment);
                    break;
                case BodyPartEnum.Ear:
                    appearances.Add(m_Ear);
                    break;
            }

            return appearances;
        }
    }
}
