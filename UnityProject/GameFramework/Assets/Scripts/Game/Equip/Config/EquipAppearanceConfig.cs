using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using System;
using System.ComponentModel;
using Main.UnityEditor;

namespace Main.Game
{
    public enum EquipSexType
    {
        Common,
        Female,
        Male,
    }
    public enum EquipPartType
    {
        // [Description("主手武器")]
        // Mainhand_Weapons = 0,
        // [Description("副手武器")]
        // Offhand_Weapons,
        [Description("头部")]
        Head,
        [Description("躯干部")]
        Torso,
        [Description("肩部")]
        Shoulders,
        [Description("腰部")]
        Hips,
        [Description("腿部")]
        Leg,
        [Description("手部")]
        Hand,
    }
    // public enum EquipAppearancePartType
    // {
    //     //Head
    //     Head,
    //     Chest,
    //     Back,
    //     Hand,
    //     Shoulders,
    //     Elbow,
    //     Leg,
    //     Knee,
    //     Extra
    // }
    [Serializable]
    public class EquipAppearanceConfig : ScriptableObject
    {
        [SerializeField] EquipAppearance_Female m_Female;
        [SerializeField] EquipAppearance_Male m_Male;
        [SerializeField] EquipAppearance_Common m_Common;
        [SerializeField] EquipAppearance_Weapon m_Weapon;
        //[EquipMesh(EquipSexType.Common, EquipAppearancePartType.Knee, 1)]


        private static EquipAppearanceConfig s_Instace;
        public static EquipAppearanceConfig S
        {
            get
            {
                if (s_Instace == null)
                {
                    s_Instace = new EquipAppearanceConfig();
                }
                return s_Instace;
            }
        }

        public EquipAppearance GetEquipAppearanceInfo(EquipPartType partType, int id)
        {
            var equipAppearance = m_Male.GetAppearanceByPart(partType, id);
            //var info = new EquipAppearanceInfo(equipAppearance);
            return equipAppearance;
        }

    }

    [Serializable]
    public class EquipAppearance_Female : EquipAppearance_Role
    {

    }

    [Serializable]
    public class EquipAppearance_Male : EquipAppearance_Role
    {

    }
    [Serializable]
    public class EquipAppearance_Common
    {
        [SerializeField] List<EquipAppearance> m_HeadAttachement;
        [SerializeField] List<EquipAppearance> m_ShoulderAttachement;
        [SerializeField] List<EquipAppearance> m_ChestAttachement;
        [SerializeField] List<EquipAppearance> m_BackAttachement;
        [SerializeField] List<EquipAppearance> m_HipAttachement;
        [SerializeField] List<EquipAppearance> m_KneeAttachement;
        [SerializeField] List<EquipAppearance> m_Extra;
    }
    [Serializable]
    public class EquipAppearance_Weapon
    {

    }

    [Serializable]
    public class EquipAppearance_Role
    {
        [SerializeField] List<EquipAppearance_Head> m_HeadAppearances;
        [SerializeField] List<EquipAppearance_Torso> m_TorsoAppearances;
        [SerializeField] List<EquipAppearance_Shoulders> m_ShouldersAppearances;
        [SerializeField] List<EquipAppearance> m_HandAppearances;
        [SerializeField] List<EquipAppearance> m_HipsAppearances;
        [SerializeField] List<EquipAppearance> m_LegAppearances;

        public EquipAppearance GetAppearanceByPart(EquipPartType partType, int id)
        {

            return m_HeadAppearances[id];
        }
    }

    [Serializable]
    public class EquipAppearance_Head : EquipAppearance
    {
        //EquipPartType partType = EquipPartType.Head;
    }
    [Serializable]
    public class EquipAppearance_Torso : EquipAppearance
    {
        // EquipPartType partType = EquipPartType.Torso;
    }
    [Serializable]
    public class EquipAppearance_Shoulders : EquipAppearance
    {
        //EquipPartType partType = EquipPartType.Shoulders;
    }


    [Serializable]
    public class EquipAppearance
    {
        [SerializeField] string name;
        //EquipPartType partType = EquipPartType.Shoulders;
        [SerializeField] public List<EquipAppearanceAttachment> attachments;
    }

    [Serializable]
    public class EquipAppearanceAttachment
    {
        [SerializeField] public BodyPartEnum part;
        [SerializeField] public int id;
    }

}
