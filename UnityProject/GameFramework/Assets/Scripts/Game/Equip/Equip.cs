using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Game
{

    public class Equip
    {
        private EquipAppearance m_Appearance;
        private EquipAttributeInfo m_Attribute;

        public EquipAppearance Appearance
        {
            get { return m_Appearance; }
        }

        public EquipAttributeInfo Attribute
        {
            get { return m_Attribute; }
        }

        public Equip(EquipAttributeInfo attribute, EquipAppearance appear)
        {
            m_Attribute = attribute;
            m_Appearance = appear;
        }
    }
}
