using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{



    public class RoleAppearResPath
    {

        static GameObject m_MeshHolder = null;
        public static GameObject MeshHolder
        {
            get
            {
                if (m_MeshHolder == null)
                {
                    IRes res = ResFactory.Create("Resources/ModularCharacters");
                    m_MeshHolder = res.asset as GameObject;
                }

                return m_MeshHolder;
            }
        }

        public static string GetMaleHeadMeshNameByIndex(int index)
        {
            var s = MeshHolder.transform.Find("Chr_Head_Male_00_Static_Mesh");
            Debug.LogError(s);
            string path = "Resources/Role/Male/Head/Prefeb/" + string.Format("Chr_Head_Male_{0}_Static_Mesh", index.ToString().PadLeft(2, '0'));
            return path;
        }
    }
}
