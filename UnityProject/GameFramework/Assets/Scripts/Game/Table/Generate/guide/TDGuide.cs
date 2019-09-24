using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GFrame;
namespace Main.Game
{
    public partial class TDGuide
    {
        private int m_Id;
        /// <summary>
        /// ID
        ///</summary>
        public int Id
        {
            get
            {
                return m_Id;
            }
        }
        private string m_Trigger;
        /// <summary>
        /// Trigger
        ///</summary>
        public string Trigger
        {
            get
            {
                return m_Trigger;
            }
        }
        private string m_CommonParam;
        /// <summary>
        /// CommonParam
        ///</summary>
        public string CommonParam
        {
            get
            {
                return m_CommonParam;
            }
        }
        private int m_RequireGuideId;
        /// <summary>
        /// RequireGuideId
        ///</summary>
        public int RequireGuideId
        {
            get
            {
                return m_RequireGuideId;
            }
        }
        private string m_JumpTrigger;
        /// <summary>
        /// JumpTrigger
        ///</summary>
        public string JumpTrigger
        {
            get
            {
                return m_JumpTrigger;
            }
        }

        public static Dictionary<string, int> GetFieldHeadIndex()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>(5);
            ret.Add("Id", 0);
            ret.Add("Trigger", 1);
            ret.Add("CommonParam", 2);
            ret.Add("RequireGuideId", 3);
            ret.Add("JumpTrigger", 4);
            return ret;
        }
        public void BindData(Dictionary<string, string> dataMap)
        {
            Dictionary<string, int> headIndexMap = GetFieldHeadIndex();
            foreach (var key in dataMap.Keys)
            {
                int col = -1;
                string value = dataMap[key];
                if (headIndexMap.TryGetValue(key, out col))
                {
                    switch (col)
                    {
                        case 0:
                            m_Id = int.Parse(value);
                            break;
                        case 1:
                            m_Trigger = value;
                            break;
                        case 2:
                            m_CommonParam = value;
                            break;
                        case 3:
                            m_RequireGuideId = int.Parse(value);
                            break;
                        case 4:
                            m_JumpTrigger = value;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}