using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDTestTable
	{
		private static Dictionary<string, TDTest> m_DataCache = new Dictionary<string, TDTest>();
		private static List<TDTest> m_DataList = new List<TDTest>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDTest> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDTest GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDTest", key));
				return null;
			}
		}
		public static void Parse()
		{
			m_DataCache.Clear();
			m_DataList.Clear();
			List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Test.json", false);
			int count = allDataList.Count;
			for (int i = 0; i < count; i++)
			{
				Dictionary<string, string> dataMap = allDataList[i];
				TDTest data = new TDTest();
				data.BindData(dataMap);
				data.Init();
				OnRowAdd(data);
				m_DataList.Add(data);
				m_DataCache.Add(data.A, data);
			}
		}
	}
}