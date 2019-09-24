using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDAd_placementTable
	{
		private static Dictionary<string, TDAd_placement> m_DataCache = new Dictionary<string, TDAd_placement>();
		private static List<TDAd_placement> m_DataList = new List<TDAd_placement>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDAd_placement> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDAd_placement GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDAd_placement", key));
				return null;
			}
		}
	}
}