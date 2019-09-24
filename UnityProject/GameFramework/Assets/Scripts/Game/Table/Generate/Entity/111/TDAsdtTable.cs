using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDAsdtTable
	{
		private static Dictionary<int, TDAsdt> m_DataCache = new Dictionary<int, TDAsdt>();
		private static List<TDAsdt> m_DataList = new List<TDAsdt>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDAsdt> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDAsdt GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDAsdt", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Asdt.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDAsdt data = new TDAsdt();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Day, data);
		}
		}
		}
	}