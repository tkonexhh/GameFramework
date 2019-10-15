using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Main.Game
{

    enum SexType
    {
        Male,
        Female
    }

    public partial class CreateRolePanel : MonoBehaviour
    {
        [SerializeField] RoleAppearance m_MaleGo;
        [SerializeField] RoleAppearance m_FemaleGo;


        private int m_HeadIndex;
        private int m_HairIndex;
        private int m_EyebrowsIndex;
        private int m_FacialHairIndex;
        private int m_TorsoIndex;
        private int m_ArmUpperIndex;
        private int m_ArmLowerIndex;
        private int m_HandIndex;
        private int m_HipsIndex;
        private int m_LegIndex;
        private int m_ShoulderIndex;
        private int m_ElbowIndex;
        private int m_KneeIndex;
        private int m_HipsAIndex;
        private int m_EarIndex;



        private void Awake()
        {
            m_ToggleFemale.onValueChanged.AddListener((bool isSelect) => { ShowRole(SexType.Female); });
            m_ToggleMale.onValueChanged.AddListener((bool isSelect) => { ShowRole(SexType.Male); });


            m_BtnHeadReduce.onClick.AddListener(() =>
            {
                m_HeadIndex--;
                RefeshBody(BodyPartEnum.Face, m_HeadIndex);
            });
            m_BtnHeadAdd.onClick.AddListener(() =>
            {
                m_HeadIndex++;
                RefeshBody(BodyPartEnum.Face, m_HeadIndex);
            });
            m_BtnHairReduce.onClick.AddListener(() =>
            {
                m_HairIndex--;
                RefeshBody(BodyPartEnum.Hair, m_HairIndex);
            });
            m_BtnHairAdd.onClick.AddListener(() =>
            {
                m_HairIndex++;
                RefeshBody(BodyPartEnum.Hair, m_HairIndex);
                //if(m_HeadIndex>=)
            });
            m_BtnEyeBrowReduce.onClick.AddListener(() =>
            {
                m_EyebrowsIndex--;
                RefeshBody(BodyPartEnum.Eyebrows, m_EyebrowsIndex);
            });
            m_BtnEyeBrowAdd.onClick.AddListener(() =>
            {
                m_EyebrowsIndex++;
                RefeshBody(BodyPartEnum.Eyebrows, m_EyebrowsIndex);
            });
            m_BtnFacialHairAdd.onClick.AddListener(() =>
            {
                m_FacialHairIndex++;
                RefeshBody(BodyPartEnum.FacialHair, m_FacialHairIndex);
            });

            m_BtnFacialHairReduce.onClick.AddListener(() =>
           {
               m_FacialHairIndex--;
               RefeshBody(BodyPartEnum.FacialHair, m_FacialHairIndex);
           });

            m_BtnTorsoAdd.onClick.AddListener(() =>
            {
                m_TorsoIndex++;
                RefeshBody(BodyPartEnum.Torso, m_TorsoIndex);
            });

            m_BtnTorsoReduce.onClick.AddListener(() =>
           {
               m_TorsoIndex--;
               RefeshBody(BodyPartEnum.Torso, m_TorsoIndex);
           });


            m_BtnArmLowerAdd.onClick.AddListener(() =>
            {
                m_ArmLowerIndex++;
                RefeshBody(BodyPartEnum.Arm_Lower, m_ArmLowerIndex);
            });

            m_BtnArmLowerReduce.onClick.AddListener(() =>
            {
                m_ArmLowerIndex--;
                RefeshBody(BodyPartEnum.Arm_Lower, m_ArmLowerIndex);
            });

            m_BtnArmUpperAdd.onClick.AddListener(() =>
            {
                m_ArmUpperIndex++;
                RefeshBody(BodyPartEnum.Arm_Upper, m_ArmUpperIndex);
            });

            m_BtnArmUpperReduce.onClick.AddListener(() =>
            {
                m_ArmUpperIndex--;
                RefeshBody(BodyPartEnum.Arm_Upper, m_ArmUpperIndex);
            });

            m_BtnHandAdd.onClick.AddListener(() =>
            {
                m_HandIndex++;
                RefeshBody(BodyPartEnum.Hand, m_HandIndex);
            });

            m_BtnHandReduce.onClick.AddListener(() =>
            {
                m_HandIndex--;
                RefeshBody(BodyPartEnum.Hand, m_HandIndex);
            });

            m_BtnHipsAdd.onClick.AddListener(() =>
            {
                m_HipsIndex++;
                RefeshBody(BodyPartEnum.Hips, m_HipsIndex);
            });

            m_BtnHipsReduce.onClick.AddListener(() =>
            {
                m_HipsIndex--;
                RefeshBody(BodyPartEnum.Hips, m_HipsIndex);
            });


            m_BtnLegAdd.onClick.AddListener(() =>
            {
                m_LegIndex++;
                RefeshBody(BodyPartEnum.Leg, m_LegIndex);
            });

            m_BtnLegReduce.onClick.AddListener(() =>
            {
                m_LegIndex--;
                RefeshBody(BodyPartEnum.Leg, m_LegIndex);
            });


            m_BtnShoulderAdd.onClick.AddListener(() =>
            {
                m_ShoulderIndex++;
                RefeshBody(BodyPartEnum.ShoulderAttachment, m_ShoulderIndex);
            });

            m_BtnShoulderReduce.onClick.AddListener(() =>
            {
                m_ShoulderIndex--;
                RefeshBody(BodyPartEnum.ShoulderAttachment, m_ShoulderIndex);
            });

            m_BtnElbowAdd.onClick.AddListener(() =>
           {
               m_ElbowIndex++;
               RefeshBody(BodyPartEnum.ElbowAttachment, m_ElbowIndex);
           });

            m_BtnElbowReduce.onClick.AddListener(() =>
            {
                m_ElbowIndex--;
                RefeshBody(BodyPartEnum.ElbowAttachment, m_ElbowIndex);
            });

            m_BtnKneeAdd.onClick.AddListener(() =>
            {
                m_KneeIndex++;
                RefeshBody(BodyPartEnum.KneeAttachment, m_KneeIndex);
            });

            m_BtnKneeReduce.onClick.AddListener(() =>
            {
                m_KneeIndex--;
                RefeshBody(BodyPartEnum.KneeAttachment, m_KneeIndex);
            });

            m_BtnHipsAAdd.onClick.AddListener(() =>
           {
               m_HipsAIndex++;
               RefeshBody(BodyPartEnum.HipsAttachment, m_HipsAIndex);
           });

            m_BtnHipsAReduce.onClick.AddListener(() =>
            {
                m_HipsAIndex--;
                RefeshBody(BodyPartEnum.HipsAttachment, m_HipsAIndex);
            });

            m_BtnEarAdd.onClick.AddListener(() =>
            {
                m_EarIndex++;
                RefeshBody(BodyPartEnum.Ear, m_EarIndex);
            });

            m_BtnEarReduce.onClick.AddListener(() =>
            {
                m_EarIndex--;
                RefeshBody(BodyPartEnum.Ear, m_EarIndex);
            });



        }


        private void ShowRole(SexType sex)
        {
            // if (sex == SexType.Male)
            // {
            //     m_MaleGo.gameObject.SetActive(true);
            // }
            // else
            // {
            //     m_MaleGo.gameObject.SetActive(false);
            // }
        }

        private void RefeshBody(BodyPartEnum partEnum, int index)
        {
            //m_MaleGo.
            m_MaleGo.ChangeBodyPart(partEnum, index);
            m_FemaleGo.ChangeBodyPart(partEnum, index);
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.M))
        //     {
        //         EquipAppearance appearance = new EquipAppearance();
        //         appearance.attachments = new List<EquipAppearanceAttachment>();
        //         EquipAppearanceAttachment a1 = new EquipAppearanceAttachment();
        //         a1.part = BodyPartEnum.Leg;
        //         a1.id = 1;
        //         EquipAppearanceAttachment a2 = new EquipAppearanceAttachment();
        //         a2.part = BodyPartEnum.KneeAttachment;
        //         a2.id = 1;
        //         appearance.attachments.Add(a1);
        //         appearance.attachments.Add(a2);
        //         Equip equip = new Equip(null, appearance);
        //         m_MaleGo.Equip(equip);
        //     }
        // }

    }
}