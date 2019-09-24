using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDApp_configTable
	{
		private static Dictionary<string, TDApp_config> m_DataCache = new Dictionary<string, TDApp_config>();
		private static List<TDApp_config> m_DataList = new List<TDApp_config>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDApp_config> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDApp_config GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDApp_config", key));
				return null;
			}
		}
	}
}