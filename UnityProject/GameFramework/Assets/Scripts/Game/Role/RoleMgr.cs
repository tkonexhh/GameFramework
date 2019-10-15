using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Main.Game
{

    public class RoleMgr : TSingleton<RoleMgr>
    {
        private RoleSourceMesh m_SourceMesh;
        public RoleSourceMesh SourceMesh
        {
            get
            {
                if (m_SourceMesh == null)
                {
                    GameObject pre = ResLoader.Allocate("asd").LoadSync("Resources/Model/ModularCharactersFBX_Source_Prefeb") as GameObject;
                    pre.SetLocalPos(Vector3.one * 5000);
                    m_SourceMesh = pre.GetComponent<RoleSourceMesh>();
                }
                return m_SourceMesh;
            }
        }
    }
}
