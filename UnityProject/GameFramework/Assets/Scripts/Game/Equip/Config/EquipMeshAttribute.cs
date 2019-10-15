using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Main.Game;

namespace Main.UnityEditor
{

    public class EquipMeshAttribute : PropertyAttribute
    {
        public EquipSexType type;
        public int id;


        public EquipMeshAttribute(EquipSexType type, int id)
        {
            this.type = type;
            this.id = id;
        }

    }
}
