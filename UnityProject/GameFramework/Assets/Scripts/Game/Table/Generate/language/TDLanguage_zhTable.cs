using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDLanguage_zhTable
	{
		private static Dictionary<string, TDLanguage_zh> m_DataCache = new Dictionary<string, TDLanguage_zh>();
		private static List<TDLanguage_zh> m_DataList = new List<TDLanguage_zh>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDLanguage_zh> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDLanguage_zh GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDLanguage_zh", key));
				return null;
			}
		}
	}
}