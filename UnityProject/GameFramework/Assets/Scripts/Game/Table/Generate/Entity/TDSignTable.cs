using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDSignTable
	{
		private static Dictionary<int, TDSign> m_DataCache = new Dictionary<int, TDSign>();
		private static List<TDSign> m_DataList = new List<TDSign>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDSign> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDSign GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDSign", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Sign.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDSign data = new TDSign();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}