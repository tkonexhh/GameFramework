using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GFrame;
namespace Main.Game
{
    public partial class TDGuide_stepTable
    {
        private static Dictionary<int, TDGuide_step> m_DataCache = new Dictionary<int, TDGuide_step>();
        private static List<TDGuide_step> m_DataList = new List<TDGuide_step>();
        public static int count
        {
            get
            {
                return m_DataCache.Count;
            }
        }
        public static List<TDGuide_step> dataList
        {
            get
            {
                return m_DataList;
            }
        }
        public static TDGuide_step GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDGuide_step", key));
                return null;
            }
        }
        public static void Parse()
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Guide_step.json", false); int count = allDataList.Count;
            for (int i = 0; i < count; i++)
            {
                Dictionary<string, string> dataMap = allDataList[i];
                TDGuide_step data = new TDGuide_step();
                data.BindData(dataMap);
                m_DataList.Add(data);
                m_DataCache.Add(data.Id, data);
            }
        }
    }
}