using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDRewardTable
	{
		private static Dictionary<int, TDReward> m_DataCache = new Dictionary<int, TDReward>();
		private static List<TDReward> m_DataList = new List<TDReward>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDReward> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDReward GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDReward", key));
				return null;
			}
		}
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Reward.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDReward data = new TDReward();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}