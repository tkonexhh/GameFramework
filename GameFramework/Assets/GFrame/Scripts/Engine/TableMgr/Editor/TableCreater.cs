using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace GFrame.UnityEditor
{

    //在面板上创建表，表名，注释，列名 类型
    //添加数据
    public class TableCreater : EditorWindow
    {
        [MenuItem("Custom/Window/TableCreaterWindow")]
        public static void CreateTable()
        {
            EditorWindow.GetWindow<TableCreater>(true, "创建配置表", true);
        }

        private const int START_WIDTH = 1;
        private const int START_HEIGHT = 4;

        static int m_Width = START_WIDTH;
        static int m_Height = START_HEIGHT;

        string m_TableName;
        string[,] m_values;
        int[] m_SelectIndex;
        int[] m_SelectType;

        private void Awake()
        {
            m_values = new string[m_Width, m_Height];
            m_SelectIndex = new int[m_Width];
            m_SelectType = new int[m_Width];
        }


        GUIStyle st = new GUIStyle(EditorStyles.popup);
        void OnGUI()
        {

            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(300));
            m_TableName = EditorGUI.TextField(rect, "表名", m_TableName);
            if (GUILayout.Button("读取配置表", GUILayout.Width(80)))
            {
                ReadTable();
            }



            //return;
            EditorGUILayout.BeginScrollView(new Vector2(50, 50));
            int posx = 20;
            int width = 80;//Screen.width / (m_Width + 1);
            for (int x = 0; x < m_Width + 2; x++)
            {
                GUILayout.BeginArea(new Rect(posx + x * width, 20, width, Screen.height - 80));
                if (x == 0)
                {
                    for (int y = 0; y < START_HEIGHT; y++)
                    {
                        EditorGUILayout.LabelField(GetTipByIndex(y));
                    }
                }
                else if (x > 0 && x < m_Width + 1)
                {
                    for (int y = 0; y < m_Height; y++)
                    {
                        if (y == 1)
                        {
                            m_SelectIndex[x - 1] = EditorGUILayout.Popup(m_SelectIndex[x - 1], new string[] { "A", "N" }, GUILayout.Width(width));
                        }
                        else if (y == 2)
                        {
                            m_SelectType[x - 1] = EditorGUILayout.Popup(m_SelectType[x - 1], new string[] { "int", "sting" }, GUILayout.Width(width));
                        }
                        else
                        {
                            //EditorGUILayout.TextField("", GUILayout.Width(width));
                            m_values[x - 1, y] = EditorGUILayout.TextField(m_values[x - 1, y], GUILayout.Width(width));
                        }

                    }
                }
                else if (x == m_Width + 1)
                {
                    if (GUILayout.Button("+", GUILayout.Width(30)))
                    {
                        AddColumn();
                    }
                }

                if (x == 1)
                {
                    if (GUILayout.Button("+", GUILayout.Width(30)))
                    {
                        AddRow();
                    }
                }

                GUILayout.EndArea();
            }


            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Reset"))
            {
                Reset();
            }
            if (GUILayout.Button("创建xlsx"))
            {
                CreateXls();
            }
        }

        private void AddColumn()
        {

            var oldValues = m_values;
            m_Width++;
            m_values = new string[m_Width, m_Height];
            for (int x = 0; x < m_Width - 1; x++)
            {
                for (int y = 0; y < m_Height; y++)
                {
                    m_values[x, y] = oldValues[x, y];
                }
            }

            var oldValues_select = m_SelectIndex;
            m_SelectIndex = new int[m_Width];
            for (int x = 0; x < m_Width - 1; x++)
            {
                m_SelectIndex[x] = oldValues_select[x];
            }

            oldValues_select = m_SelectType;
            m_SelectType = new int[m_Width];
            for (int x = 0; x < m_Width - 1; x++)
            {
                m_SelectType[x] = oldValues_select[x];
            }
        }

        private void AddRow()
        {
            var oldValues = m_values;
            m_Height++;
            m_values = new string[m_Width, m_Height];
            for (int x = 0; x < m_Width; x++)
            {
                for (int y = 0; y < m_Height - 1; y++)
                {
                    m_values[x, y] = oldValues[x, y];
                }
            }


        }

        void CreateXls()
        {

        }

        void ReadTable()
        {

        }

        string GetTipByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return "注释";
                case 1:
                    return "是否注释列";
                case 2:
                    return "类型";
                case 3:
                    return "变量名";
            }
            return "";
        }

        void Reset()
        {
            m_Width = START_WIDTH;
            m_Height = START_HEIGHT;
            m_SelectIndex = new int[m_Width];
            m_SelectType = new int[m_Width];
            m_values = new string[m_Width, m_Height];
        }
    }


}




