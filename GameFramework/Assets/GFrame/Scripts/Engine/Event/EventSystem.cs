using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{

    public delegate void OnEvent(int key, params object[] param);
    public class EventSystem : TSingleton<EventSystem>
    {



        private class ListenerWarp
        {
            private LinkedList<OnEvent> m_EventList;

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
                return true;
            }
        }


        #region func

        public void Register()
        {

        }

        public void UnRegister()
        {

        }

        public void Send()
        {

        }
        #endregion
    }
}
