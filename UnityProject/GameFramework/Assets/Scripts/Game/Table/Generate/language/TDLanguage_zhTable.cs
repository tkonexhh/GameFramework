using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDLanguage_zhTable
	{
		private static Dictionary<string, TDLanguage_zh> m_DataCache = new Dictionary<string, TDLanguage_zh>();
		private static List<TDLanguage_zh> m_DataList = new List<TDLanguage_zh>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDLanguage_zh> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDLanguage_zh GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDLanguage_zh", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Language_zh.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDLanguage_zh data = new TDLanguage_zh();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}