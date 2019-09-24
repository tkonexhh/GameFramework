using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDFlopTable
	{
		private static Dictionary<int, TDFlop> m_DataCache = new Dictionary<int, TDFlop>();
		private static List<TDFlop> m_DataList = new List<TDFlop>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDFlop> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDFlop GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDFlop", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Flop.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDFlop data = new TDFlop();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}