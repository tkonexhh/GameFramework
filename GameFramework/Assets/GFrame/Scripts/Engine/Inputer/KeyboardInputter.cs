using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{

    public class KeyboardInputter : IKeyboardInputter
    {

        private List<KeyCodeMonitor> m_MonitorList;
        private bool m_IsEnable = true;
        public bool isEnable
        {
            get { return m_IsEnable; }
            set { m_IsEnable = value; }
        }


        public void RegisterKeyCodeMonitor(KeyCode code, Run begin, Run process, Run end)//普通点击
        {
            AddKeyCodeMonitor(KeyBoardInputType.Click, new KeyCode[] { code }, begin, process, end);
        }
        public void RegisterShortcuts(KeyCode[] code, Run end)//快捷键
        {
            AddKeyCodeMonitor(KeyBoardInputType.Shortcuts, code, null, null, end);
        }
        public void RegisterKeyCodeQueue(KeyCode[] code, Run begin, Run process, Run end)//连招
        {
            AddKeyCodeMonitor(KeyBoardInputType.Sequeue, code, begin, process, end);
        }

        private void AddKeyCodeMonitor(KeyBoardInputType type, KeyCode[] code, Run begin, Run process, Run end)
        {
            KeyCodeMonitor monitor = new KeyCodeMonitor(type, code, begin, process, end);
            if (m_MonitorList == null)
            {
                m_MonitorList = new List<KeyCodeMonitor>();
            }
            m_MonitorList.Add(monitor);
        }

        public void OnLateUpdate()
        {
            if (!m_IsEnable)
            {
                return;
            }

            if (m_MonitorList == null || m_MonitorList.Count == 0)
            {
                return;
            }

            //处理各种键盘事件
            for (int i = m_MonitorList.Count - 1; i >= 0; --i)
            {
                m_MonitorList[i].OnLateUpdate();
            }
        }



        #region 按键监控

        private enum KeyBoardInputType
        {
            Click,
            Shortcuts,
            Sequeue,
        }

        private class KeyCodeMonitor
        {
            private KeyBoardInputType m_InputType;
            private Run m_BeginDelegate;
            private Run m_PrecessingDelegate;
            private Run m_EndDelegate;
            private bool m_IsPrecessing = false;

            private KeyCode[] m_Codes;


            // public KeyCodeMonitor(KeyCode code, Run begin, Run process, Run end)
            // {
            //     m_InputType = KeyBoardInputType.Click;
            //     m_Codes = new KeyCode[1];
            //     m_Codes[0] = code;
            // }

            public KeyCodeMonitor(KeyBoardInputType type, KeyCode[] code, Run begin, Run process, Run end)
            {
                m_IsPrecessing = false;
                m_InputType = type;
                m_Codes = code;
                m_BeginDelegate = begin;
                m_PrecessingDelegate = process;
                m_EndDelegate = end;
            }

            /*
            & = Alternate
             ^ = Control
            % = Command/Windows key
            # = Shift 
             */
            public void OnLateUpdate()
            {
                if (m_InputType == KeyBoardInputType.Click)
                {
                    if (Input.GetKey(m_Codes[0]))
                    {
                        if (!m_IsPrecessing)
                        {
                            m_IsPrecessing = true;
                            if (m_BeginDelegate != null)
                            {
                                m_BeginDelegate();
                            }
                        }
                        else
                        {
                            if (m_PrecessingDelegate != null)
                            {
                                m_PrecessingDelegate();
                            }
                        }
                    }
                    else
                    {
                        if (m_IsPrecessing)
                        {
                            m_IsPrecessing = false;
                            if (m_EndDelegate != null)
                            {
                                m_EndDelegate();
                            }
                        }
                    }
                }
                else if (m_InputType == KeyBoardInputType.Shortcuts)
                {
                    IterationClick(0);
                }
                else
                {
                    //处理连击相关
                }

            }


            private void IterationClick(int index)
            {
                if (Input.GetKey(m_Codes[index]))
                {
                    if (index < m_Codes.Length - 1)
                    {
                        IterationClick(index + 1);
                    }
                    else //最后一个按键了
                    {
                        if (!m_IsPrecessing)
                        {
                            m_IsPrecessing = true;
                            if (m_EndDelegate != null)
                            {
                                m_EndDelegate();
                            }
                        }
                    }
                }
                else
                {
                    if (m_IsPrecessing)
                    {
                        m_IsPrecessing = false;
                    }
                }
            }


        }
        #endregion
    }
}




