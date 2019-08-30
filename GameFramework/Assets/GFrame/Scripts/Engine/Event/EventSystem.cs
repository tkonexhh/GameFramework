﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{

    public delegate void OnEvent(int key, params object[] param);
    public class EventSystem : TSingleton<EventSystem>
    {

        private Dictionary<int, ListenerWarp> m_ListenerMap = new Dictionary<int, ListenerWarp>();

        #region 内部监听类
        private class ListenerWarp
        {
            private LinkedList<OnEvent> m_EventList;

            //向链表中的每一个委托发送消息
            public bool Send(int key, params object[] param)
            {
                if (m_EventList == null || m_EventList.Count == 0)
                {
                    return false;
                }

                LinkedListNode<OnEvent> next = m_EventList.First;
                OnEvent call = null;
                LinkedListNode<OnEvent> nextCache = null;

                while (next != null)
                {
                    call = next.Value;
                    call(key, param);
                    nextCache = next.Next;

                    if (nextCache == null)
                    {
                        next = null;
                    }
                    else
                    {
                        next = nextCache;
                    }
                }


                return true;
            }


            public bool Add(OnEvent listener)
            {
                if (m_EventList == null)
                {
                    m_EventList = new LinkedList<OnEvent>();
                }

                if (m_EventList.Contains(listener))
                {
                    return false;
                }
                m_EventList.AddLast(listener);
                return true;
            }

            public void Remove(OnEvent listener)
            {
                if (m_EventList == null)
                {
                    return;
                }

                m_EventList.Remove(listener);
            }
        }
        #endregion

        #region func

        public bool Register(int key, OnEvent func)
        {
            ListenerWarp warp;
            if (!m_ListenerMap.TryGetValue(key, out warp))
            {
                warp = new ListenerWarp();
                m_ListenerMap.Add(key, warp);
            }

            if (warp.Add(func))
            {
                return true;
            }


            return false;
        }

        public void UnRegister(int key, OnEvent func)
        {
            ListenerWarp warp;
            if (m_ListenerMap.TryGetValue(key, out warp))
            {
                warp.Remove(func);
            }

        }

        public bool Send(int key, params object[] param)
        {
            ListenerWarp warp;
            if (m_ListenerMap.TryGetValue(key, out warp))
            {
                return warp.Send(key, param);
            }

            return false;
        }
        #endregion
    }
}
