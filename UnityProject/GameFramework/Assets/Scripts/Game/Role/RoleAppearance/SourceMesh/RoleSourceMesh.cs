using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RoleMeshPart
{
    HeadCoverings_Base_Hair,
    HeadCoverings_No_FacialHair,
    HeadCoverings_No_Hair,
    All_01_Hair,
    All_02_Head_Attachment,
    All_03_Chest_Attachment,
    All_04_Back_Attachment,
    All_05_Shoulder_Attachment_Right,
    All_06_Shoulder_Attachment_Left,
    All_07_Elbow_Attachment_Right,
    All_08_Elbow_Attachment_Left,
    All_09_Hips_Attachment,
    All_10_Knee_Attachement_Right,
    All_11_Knee_Attachement_Left,
    All_12_Extra,
    /////////////////////////////////
    Female_Head_All_Elements,
    Female_Head_No_Elements,
    Female_01_Eyebrows,
    Female_02_FacialHair,
    Female_03_Torso,
    Female_04_Arm_Upper_Right,
    Female_05_Arm_Upper_Left,
    Female_06_Arm_Lower_Right,
    Female_07_Arm_Lower_Left,
    Female_08_Hand_Right,
    Female_09_Hand_Left,
    Female_10_Hips,
    Female_11_Leg_Right,
    Female_12_Leg_Left,
    /////////////////////////////////    
    Male_Head_All_Elements,
    Male_Head_No_Elements,
    Male_01_Eyebrows,
    Male_02_FacialHair,
    Male_03_Torso,
    Male_04_Arm_Upper_Right,
    Male_05_Arm_Upper_Left,
    Male_06_Arm_Lower_Right,
    Male_07_Arm_Lower_Left,
    Male_08_Hand_Right,
    Male_09_Hand_Left,
    Male_10_Hips,
    Male_11_Leg_Right,
    Male_12_Leg_Left,
}

public class RoleSourceMesh : MonoBehaviour
{

    #region define
    #region All_Gender_Parts
    [Header("All_Gender_Parts")]
    [Header("All_00_HeadCoverings")]
    [Header("HeadCoverings_Base_Hair")]
    [SerializeField] private RoleSourceMeshPart m_Part_HeadCoverings_Base_Hair;
    [Header("HeadCoverings_No_FacialHair")]
    [SerializeField] private RoleSourceMeshPart m_Part_HeadCoverings_No_FacialHair;
    [Header("HeadCoverings_No_Hair")]
    [SerializeField] private RoleSourceMeshPart m_Part_HeadCoverings_No_Hair;
    [Header("All_01_Hair")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_01_Hair;
    [Header("All_02_Head_Attachment")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_02_Head_Attachment;
    [Header("All_04_Back_Attachment")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_04_Back_Attachment;
    [Header("All_05_Shoulder_Attachment_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_05_Shoulder_Attachment_Right;
    [Header("All_06_Shoulder_Attachment_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_06_Shoulder_Attachment_Left;
    [Header("All_07_Elbow_Attachment_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_07_Elbow_Attachment_Right;
    [Header("All_08_Elbow_Attachment_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_08_Elbow_Attachment_Left;
    [Header("All_09_Hips_Attachment")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_09_Hips_Attachment;
    [Header("All_10_Knee_Attachement_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_10_Knee_Attachement_Right;
    [Header("All_11_Knee_Attachement_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_11_Knee_Attachement_Left;
    [Header("All_12_Extra")]
    [SerializeField] private RoleSourceMeshPart m_Part_All_12_Extra;

    #region Female_Parts
    [Header("Female_00_Head")]
    [Header("Female_Head_All_Elements")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_Head_All_Elements;
    [Header("Female_Head_No_Elements")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_Head_No_Elements;
    [Header("Female_01_Eyebrows")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_01_Eyebrows;
    [Header("Female_02_FacialHair")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_02_FacialHair;
    [Header("Female_03_Torso")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_03_Torso;
    [Header("Female_04_Arm_Upper_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_04_Arm_Upper_Right;
    [Header("Female_05_Arm_Upper_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_05_Arm_Upper_Left;
    [Header("Female_06_Arm_Lower_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_06_Arm_Lower_Right;
    [Header("Female_07_Arm_Lower_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_07_Arm_Lower_Left;
    [Header("Female_08_Hand_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_08_Hand_Right;
    [Header("Female_09_Hand_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_09_Hand_Left;
    [Header("Female_10_Hips")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_10_Hips;
    [Header("Female_11_Leg_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_11_Leg_Right;
    [Header("Female_12_Leg_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Female_12_Leg_Left;
    #endregion
    #region Male_Parts
    [Header("Male_00_Head")]
    [Header("Male_Head_All_Elements")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_Head_All_Elements;
    [Header("Male_Head_No_Elements")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_Head_No_Elements;
    [Header("Male_01_Eyebrows")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_01_Eyebrows;
    [Header("Male_02_FacialHair")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_02_FacialHair;
    [Header("Male_03_Torso")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_03_Torso;
    [Header("Male_04_Arm_Upper_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_04_Arm_Upper_Right;
    [Header("Male_05_Arm_Upper_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_05_Arm_Upper_Left;
    [Header("Male_06_Arm_Lower_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_06_Arm_Lower_Right;
    [Header("Male_07_Arm_Lower_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_07_Arm_Lower_Left;
    [Header("Male_08_Hand_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_08_Hand_Right;
    [Header("Male_09_Hand_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_09_Hand_Left;
    [Header("Male_10_Hips")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_10_Hips;
    [Header("Male_11_Leg_Right")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_11_Leg_Right;
    [Header("Male_12_Leg_Left")]
    [SerializeField] private RoleSourceMeshPart m_Part_Male_12_Leg_Left;

    #endregion
    #endregion
    #endregion
    void Awake()
    {

    }

    public RoleSourceMeshPart GetRoleMeshPartByType(RoleMeshPart type)
    {
        switch (type)
        {
            case RoleMeshPart.HeadCoverings_Base_Hair:
                return m_Part_HeadCoverings_Base_Hair;
            case RoleMeshPart.HeadCoverings_No_FacialHair:
                return m_Part_HeadCoverings_No_FacialHair;
            case RoleMeshPart.HeadCoverings_No_Hair:
                return m_Part_HeadCoverings_No_Hair;
            case RoleMeshPart.All_01_Hair:
                return m_Part_All_01_Hair;
            case RoleMeshPart.All_02_Head_Attachment:
                return m_Part_All_02_Head_Attachment;
            case RoleMeshPart.All_03_Chest_Attachment:
                return null;
            case RoleMeshPart.All_04_Back_Attachment:
                return m_Part_All_04_Back_Attachment;
            case RoleMeshPart.All_05_Shoulder_Attachment_Right:
                return m_Part_All_05_Shoulder_Attachment_Right;
            case RoleMeshPart.All_06_Shoulder_Attachment_Left:
                return m_Part_All_06_Shoulder_Attachment_Left;
            case RoleMeshPart.All_07_Elbow_Attachment_Right:
                return m_Part_All_07_Elbow_Attachment_Right;
            case RoleMeshPart.All_08_Elbow_Attachment_Left:
                return m_Part_All_08_Elbow_Attachment_Left;
            case RoleMeshPart.All_09_Hips_Attachment:
                return m_Part_All_09_Hips_Attachment;
            case RoleMeshPart.All_10_Knee_Attachement_Right:
                return m_Part_All_10_Knee_Attachement_Right;
            case RoleMeshPart.All_11_Knee_Attachement_Left:
                return m_Part_All_11_Knee_Attachement_Left;
            case RoleMeshPart.All_12_Extra:
                return m_Part_All_12_Extra;
            //////////////
            case RoleMeshPart.Female_Head_All_Elements:
                return m_Part_Female_Head_All_Elements;
            case RoleMeshPart.Female_Head_No_Elements:
                return m_Part_Female_Head_No_Elements;
            case RoleMeshPart.Female_01_Eyebrows:
                return m_Part_Female_01_Eyebrows;
            case RoleMeshPart.Female_02_FacialHair:
                return m_Part_Female_02_FacialHair;
            case RoleMeshPart.Female_03_Torso:
                return m_Part_Female_03_Torso;
            case RoleMeshPart.Female_04_Arm_Upper_Right:
                return m_Part_Female_04_Arm_Upper_Right;
            case RoleMeshPart.Female_05_Arm_Upper_Left:
                return m_Part_Female_05_Arm_Upper_Left;
            case RoleMeshPart.Female_06_Arm_Lower_Right:
                return m_Part_Female_06_Arm_Lower_Right;
            case RoleMeshPart.Female_07_Arm_Lower_Left:
                return m_Part_Female_07_Arm_Lower_Left;
            case RoleMeshPart.Female_08_Hand_Right:
                return m_Part_Female_08_Hand_Right;
            case RoleMeshPart.Female_09_Hand_Left:
                return m_Part_Female_09_Hand_Left;
            case RoleMeshPart.Female_10_Hips:
                return m_Part_Female_10_Hips;
            case RoleMeshPart.Female_11_Leg_Right:
                return m_Part_Female_11_Leg_Right;
            case RoleMeshPart.Female_12_Leg_Left:
                return m_Part_Female_12_Leg_Left;
            ///////////////
            case RoleMeshPart.Male_Head_All_Elements:
                return m_Part_Male_Head_All_Elements;
            case RoleMeshPart.Male_Head_No_Elements:
                return m_Part_Male_Head_No_Elements;
            case RoleMeshPart.Male_01_Eyebrows:
                return m_Part_Male_01_Eyebrows;
            case RoleMeshPart.Male_02_FacialHair:
                return m_Part_Male_02_FacialHair;
            case RoleMeshPart.Male_03_Torso:
                return m_Part_Male_03_Torso;
            case RoleMeshPart.Male_04_Arm_Upper_Right:
                return m_Part_Male_04_Arm_Upper_Right;
            case RoleMeshPart.Male_05_Arm_Upper_Left:
                return m_Part_Male_05_Arm_Upper_Left;
            case RoleMeshPart.Male_06_Arm_Lower_Right:
                return m_Part_Male_06_Arm_Lower_Right;
            case RoleMeshPart.Male_07_Arm_Lower_Left:
                return m_Part_Male_07_Arm_Lower_Left;
            case RoleMeshPart.Male_08_Hand_Right:
                return m_Part_Male_08_Hand_Right;
            case RoleMeshPart.Male_09_Hand_Left:
                return m_Part_Male_09_Hand_Left;
            case RoleMeshPart.Male_10_Hips:
                return m_Part_Male_10_Hips;
            case RoleMeshPart.Male_11_Leg_Right:
                return m_Part_Male_11_Leg_Right;
            case RoleMeshPart.Male_12_Leg_Left:
                return m_Part_Male_12_Leg_Left;
        }

        return null;
    }

    public SkinnedMeshRenderer GetRoleMeshByType(RoleMeshPart type, int index)
    {
        RoleSourceMeshPart part = GetRoleMeshPartByType(type);
        if (part != null)
        {
            return part.GetMeshByIndex(index);
        }
        return null;
    }

    public int GetCountByType(RoleMeshPart type)
    {
        RoleSourceMeshPart part = GetRoleMeshPartByType(type);
        if (part != null)
        {
            return part.GetMeshCount();
        }
        return -1;
    }

}
