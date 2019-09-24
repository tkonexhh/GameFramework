using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDGuideTable
	{
		private static Dictionary<int, TDGuide> m_DataCache = new Dictionary<int, TDGuide>();
		private static List<TDGuide> m_DataList = new List<TDGuide>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDGuide> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDGuide GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDGuide", key));
				return null;
			}
		}
	}
}