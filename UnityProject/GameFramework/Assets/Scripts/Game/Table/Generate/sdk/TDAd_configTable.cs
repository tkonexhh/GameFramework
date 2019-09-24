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
	}
}