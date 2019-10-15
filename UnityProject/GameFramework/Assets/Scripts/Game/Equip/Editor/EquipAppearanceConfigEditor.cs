using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GFrame;
using GFrame.UnityEditor;
using Main.Game;


namespace Main.UnityEditor
{
    public class EquipAppearanceConfigEditor
    {
        private const string CONFIG_NAME = "EquipAppearanceConfig.asset";

        [MenuItem("Assets/Game/Config/Build EquipAppearanceConfig")]
        public static void BuildAppConfig()
        {
            BaseConfigEditor<EquipAppearanceConfig>.BuildConfig(FilePath.projectConfigPath, CONFIG_NAME);
        }
    }

    [CustomEditor(typeof(EquipAppearanceConfig))]
    public class EquipAppearanceConfigInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            EquipAppearanceConfig config = target as EquipAppearanceConfig;
            if (GUILayout.Button("SAVE JSON"))
            {
                SerializeHelper.SerializeJson(FilePath.persistentDataPath4Cache, config, false);
            }
            if (GUILayout.Button("LOAD JSON"))
            {
                //SerializeHelper.SerializeJson(FilePath.persistentDataPath4Cache, config, false);
            }
        }
    }

    // public class EquipAppearanceConfigWindow : EditorWindow
    // {
    //     private SerializedObject serializedObject;

    //     [MenuItem("Assets/Game/Window/Show EquipAppearanceWindow")]
    //     public static void ShowObjectWindow()
    //     {
    //         var window = EditorWindow.GetWindow<EquipAppearanceConfigWindow>(true, "ShowObject Window", true);
    //         // 创建ScriptableObject并生成SerializedObject
    //         window.serializedObject = new SerializedObject(ScriptableObject.CreateInstance<EquipAppearanceConfig>());
    //     }

    //     private void OnGUI()
    //     {
    //         // 绘制ScriptableObject的Inspector显示，目前是空的
    //         //this.serializedObject.Update();
    //     }
    // }
}
