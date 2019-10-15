using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Main.UnityEditor
{

    [CustomPropertyDrawer(typeof(EquipMeshAttribute))]
    public class EquipMeshAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //获取绘制描述类
            EquipMeshAttribute range = this.attribute as EquipMeshAttribute;
            EditorGUI.LabelField(position, "123123123123");
            EditorGUI.Slider(position, property, 0, 1, label);
        }
    }
}
