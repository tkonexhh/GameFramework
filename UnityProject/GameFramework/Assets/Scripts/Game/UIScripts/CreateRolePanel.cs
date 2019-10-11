using System;
using System.Collections;
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


        private int m_HeadIndex;
        private int m_EyebrowsIndex;
        private int m_FacialHairIndex;
        private int m_TorsoIndex;
        private int m_ArmUpperIndex;
        private int m_ArmLowerIndex;
        private int m_HandIndex;
        private int m_HipsIndex;
        private int m_LegIndex;


        private int m_MaxHeadIndex;
        private int m_MaxEyebrowsIndex;

        private void Awake()
        {
            m_ToggleFemale.onValueChanged.AddListener((bool isSelect) => { ShowRole(SexType.Female); });
            m_ToggleMale.onValueChanged.AddListener((bool isSelect) => { ShowRole(SexType.Male); });


            m_BtnHeadReduce.onClick.AddListener(() =>
            {
                m_HeadIndex--;
                RefeshBody(BodyPartEnum.Head, m_HeadIndex);
            });
            m_BtnHeadAdd.onClick.AddListener(() =>
            {
                m_HeadIndex++;
                RefeshBody(BodyPartEnum.Head, m_HeadIndex);
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
        }


        private void ShowRole(SexType sex)
        {
            if (sex == SexType.Male)
            {
                m_MaleGo.gameObject.SetActive(true);
            }
            else
            {
                m_MaleGo.gameObject.SetActive(false);
            }
        }

        private void RefeshBody(BodyPartEnum partEnum, int index)
        {
            m_MaleGo.ChangeBodyPart(partEnum, index);
        }

    }
}