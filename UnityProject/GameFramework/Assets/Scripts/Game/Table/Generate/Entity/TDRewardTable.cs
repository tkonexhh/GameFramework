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
	}
}