using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDAd_configTable
	{
		private static Dictionary<string, TDAd_config> m_DataCache = new Dictionary<string, TDAd_config>();
		private static List<TDAd_config> m_DataList = new List<TDAd_config>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDAd_config> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDAd_config GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDAd_config", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Ad_config.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDAd_config data = new TDAd_config();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}