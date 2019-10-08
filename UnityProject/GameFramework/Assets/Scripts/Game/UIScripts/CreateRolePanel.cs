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


        private RoleHead m_RoleHead;

        private int m_HeadIndex;
        private int m_EyebrowsIndex;
        private int m_MaxHeadIndex;
        private int m_MaxEyebrowsIndex;

        private void Awake()
        {
            m_ToggleFemale.onValueChanged.AddListener((bool isSelect) => { ShowRole(SexType.Female); });
            m_ToggleMale.onValueChanged.AddListener((bool isSelect) => { ShowRole(SexType.Male); });


            m_BtnHeadReduce.onClick.AddListener(() =>
            {
                m_HeadIndex--;
                RefeshHead(m_HeadIndex);
            });
            m_BtnHeadAdd.onClick.AddListener(() =>
            {
                m_HeadIndex++;
                RefeshHead(m_HeadIndex);
                //if(m_HeadIndex>=)
            });
            m_BtnEyeBrowReduce.onClick.AddListener(() =>
            {
                m_EyebrowsIndex--;
                RefeshEyebrows(m_EyebrowsIndex);
            });
            m_BtnEyeBrowAdd.onClick.AddListener(() =>
            {
                m_EyebrowsIndex++;
                RefeshEyebrows(m_EyebrowsIndex);
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

        private void RefeshHead(int index)
        {
            m_MaleGo.ChangeBodyPart(BodyPartEnum.Head, m_HeadIndex);
        }

        private void RefeshEyebrows(int index)
        {

        }

    }
}