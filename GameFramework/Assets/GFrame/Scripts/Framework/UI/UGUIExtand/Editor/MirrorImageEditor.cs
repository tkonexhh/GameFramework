using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace GFrame
{



    [CustomEditor(typeof(MirrorImage))]
    public class MirrorImageEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            MirrorImage mirror = target as MirrorImage;
            EditorGUILayout.Space();
            if (GUILayout.Button("SetNativeSize"))
            {
                mirror.SetNativeSize();
            }
        }
    }
}
