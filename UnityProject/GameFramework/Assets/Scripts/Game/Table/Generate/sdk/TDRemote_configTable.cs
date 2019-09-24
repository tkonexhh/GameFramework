using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDRemote_configTable
	{
		private static Dictionary<string, TDRemote_config> m_DataCache = new Dictionary<string, TDRemote_config>();
		private static List<TDRemote_config> m_DataList = new List<TDRemote_config>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDRemote_config> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDRemote_config GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDRemote_config", key));
				return null;
			}
		}
	}
}