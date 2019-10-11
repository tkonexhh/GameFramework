using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{



    public class RoleAppearResPath
    {
        private const string m_RoleRes = "Resources/Role";
        private const string m_SoureRes = "Resources/Model/ModularCharacters_Source_Prefeb";

        public static string GetMaleHeadMeshNameByIndex(int index)
        {
            string path = m_RoleRes + "/Male/Head/Prefab/" + string.Format("Chr_Head_Male_{0}_Static_Prefeb", index.ToString().PadLeft(2, '0'));
            return path;
        }
        public static string GetMaleEyebrowMeshNameByIndex(int index)
        {
            string path = m_RoleRes + "/Male/Eyebrow/Prefab/" + string.Format("Chr_Eyebrow_Male_{0}_Static", index.ToString().PadLeft(2, '0'));
            return path;
        }
        public static string GetMaleFacialHairMeshNameByIndex(int index)
        {
            string path = m_RoleRes + "/Male/FacialHair/Prefab/" + string.Format("Chr_FacialHair_Male_{0}_Static", index.ToString().PadLeft(2, '0'));
            return path;
        }

        public static string GetMaleTorsoMeshNameByIndex(int index)
        {
            string path = m_RoleRes + "/Male/Torso/Prefab/" + string.Format("Chr_Torso_Male_{0}_Static", index.ToString().PadLeft(2, '0'));
            return path;
        }
    }
}
