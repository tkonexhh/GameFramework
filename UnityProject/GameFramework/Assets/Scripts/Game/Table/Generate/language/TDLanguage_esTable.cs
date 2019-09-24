using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDLanguage_esTable
	{
		private static Dictionary<string, TDLanguage_es> m_DataCache = new Dictionary<string, TDLanguage_es>();
		private static List<TDLanguage_es> m_DataList = new List<TDLanguage_es>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDLanguage_es> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDLanguage_es GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDLanguage_es", key));
				return null;
			}
		}
	}
}