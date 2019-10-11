using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RoleMeshPart
{

    HeadCoverings_Base_Hair,
    HeadCoverings_No_FacialHair,
    Male_Head_All_Elements,
    Male_Head_No_Elements
}

public class RoleSourceMesh : MonoBehaviour
{

    #region define
    #region All_Gender_Parts
    [Header("All_Gender_Parts")]
    [Header("All_00_HeadCoverings")]
    [SerializeField] private Transform m_TransHeadCoverings_Base_Hair;
    [SerializeField] private SkinnedMeshRenderer[] m_HeadCoverings_Base_Hair;
    [SerializeField] private Transform m_TransHeadCoverings_No_FacialHair;
    [SerializeField] private SkinnedMeshRenderer[] m_HeadCoverings_No_FacialHair;
    [SerializeField] private Transform m_TransHeadCoverings_No_Hair;
    [SerializeField] private SkinnedMeshRenderer[] m_HeadCoverings_No_Hair;
    [Header("All_01_Hair")]
    [SerializeField] private Transform m_TransAll_01_Hair;
    [SerializeField] private SkinnedMeshRenderer[] m_All_01_Hair;
    [Header("All_02_Head_Attachment")]
    [SerializeField] private Transform m_TransAll_02_Head_Attachment;
    [SerializeField] private SkinnedMeshRenderer[] m_All_02_Head_Attachment;
    [Header("All_04_Back_Attachment")]
    [SerializeField] private Transform m_TransAll_04_Back_Attachment;
    [SerializeField] private SkinnedMeshRenderer[] m_All_04_Back_Attachment;
    [Header("All_05_Shoulder_Attachment_Right")]
    [SerializeField] private Transform m_TransAll_05_Shoulder_Attachment_Right;
    [SerializeField] private SkinnedMeshRenderer[] m_All_05_Shoulder_Attachment_Right;

    [Header("All_06_Shoulder_Attachment_Left")]
    [SerializeField] private Transform m_TransAll_06_Shoulder_Attachment_Left;
    [SerializeField] private SkinnedMeshRenderer[] m_All_06_Shoulder_Attachment_Left;
    [Header("All_07_Elbow_Attachment_Right")]
    [SerializeField] private Transform m_TransAll_07_Elbow_Attachment_Right;
    [SerializeField] private SkinnedMeshRenderer[] m_All_07_Elbow_Attachment_Right;
    [Header("All_08_Elbow_Attachment_Left")]
    [SerializeField] private Transform m_TransAll_08_Elbow_Attachment_Left;
    [SerializeField] private SkinnedMeshRenderer[] m_All_08_Elbow_Attachment_Left;
    [Header("All_09_Hips_Attachment")]
    [SerializeField] private Transform m_TransAll_09_Hips_Attachment;
    [SerializeField] private SkinnedMeshRenderer[] m_All_09_Hips_Attachment;
    [Header("All_10_Knee_Attachement_Right")]
    [SerializeField] private Transform m_TransAll_10_Knee_Attachement_Right;
    [SerializeField] private SkinnedMeshRenderer[] m_All_10_Knee_Attachement_Right;
    [Header("All_11_Knee_Attachement_Left")]
    [SerializeField] private Transform m_TransAll_11_Knee_Attachement_Left;
    [SerializeField] private SkinnedMeshRenderer[] m_All_11_Knee_Attachement_Left;
    [Header("All_12_Extra")]
    [SerializeField] private Transform m_TransAll_12_Extra;
    [SerializeField] private SkinnedMeshRenderer[] m_All_12_Extra;

    #region Female_Parts
    #endregion
    #region Male_Parts
    [Header("Male_00_Head")]
    [Header("Male_Head_All_Elements")]
    [SerializeField] private Transform m_TransMale_Head_All_Elements;
    [SerializeField] private SkinnedMeshRenderer[] m_Male_Head_All_Elements;
    [Header("Male_Head_No_Elements")]
    [SerializeField] private Transform m_TransMale_Head_No_Elements;
    [SerializeField] private SkinnedMeshRenderer[] m_Male_Head_No_Elements;
    #endregion
    #endregion
    #endregion
    void Awake()
    {
        m_HeadCoverings_Base_Hair = m_TransHeadCoverings_Base_Hair.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_HeadCoverings_No_FacialHair = m_TransHeadCoverings_No_FacialHair.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_HeadCoverings_No_Hair = m_TransHeadCoverings_No_Hair.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_01_Hair = m_TransAll_01_Hair.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_02_Head_Attachment = m_TransAll_02_Head_Attachment.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_04_Back_Attachment = m_TransAll_04_Back_Attachment.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_05_Shoulder_Attachment_Right = m_TransAll_05_Shoulder_Attachment_Right.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_06_Shoulder_Attachment_Left = m_TransAll_06_Shoulder_Attachment_Left.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_07_Elbow_Attachment_Right = m_TransAll_07_Elbow_Attachment_Right.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_08_Elbow_Attachment_Left = m_TransAll_08_Elbow_Attachment_Left.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_09_Hips_Attachment = m_TransAll_09_Hips_Attachment.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_10_Knee_Attachement_Right = m_TransAll_10_Knee_Attachement_Right.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_11_Knee_Attachement_Left = m_TransAll_11_Knee_Attachement_Left.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_All_12_Extra = m_TransAll_12_Extra.GetComponentsInChildren<SkinnedMeshRenderer>();

        m_Male_Head_All_Elements = m_TransMale_Head_All_Elements.GetComponentsInChildren<SkinnedMeshRenderer>();
        m_Male_Head_No_Elements = m_TransMale_Head_No_Elements.GetComponentsInChildren<SkinnedMeshRenderer>();
    }


    public SkinnedMeshRenderer GetMaleMeshByType(RoleMeshPart type, int index)
    {
        switch (type)
        {
            case RoleMeshPart.Male_Head_All_Elements:
                return GetMaleHeadAllElementsByIndex(index);
            case RoleMeshPart.Male_Head_No_Elements:
                return GetMaleHeadNoElementsByIndex(index);
        }

        return null;
    }

    public SkinnedMeshRenderer GetMaleHeadAllElementsByIndex(int index)
    {
        return BaseGetMesh(index, m_Male_Head_All_Elements);
    }

    public SkinnedMeshRenderer GetMaleHeadNoElementsByIndex(int index)
    {
        return BaseGetMesh(index, m_Male_Head_No_Elements);
    }

    public SkinnedMeshRenderer BaseGetMesh(int index, SkinnedMeshRenderer[] skins)
    {
        if (skins == null || skins.Length <= 0)
        {
            return null;
        }

        if (index < 0 || index >= skins.Length)
            return skins[0];

        return skins[index];
    }


}
