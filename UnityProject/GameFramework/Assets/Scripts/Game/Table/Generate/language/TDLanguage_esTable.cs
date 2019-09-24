using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDLanguage_esTable
	{
		private static Dictionary<string, TDLanguage_es> m_DataCache = new Dictionary<string, TDLanguage_es>();
		private static List<TDLanguage_es> m_DataList = new List<TDLanguage_es>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDLanguage_es> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDLanguage_es GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDLanguage_es", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Language_es.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDLanguage_es data = new TDLanguage_es();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}