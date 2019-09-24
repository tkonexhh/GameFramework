using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDGuide_stepTable
	{
		private static Dictionary<int, TDGuide_step> m_DataCache = new Dictionary<int, TDGuide_step>();
		private static List<TDGuide_step> m_DataList = new List<TDGuide_step>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDGuide_step> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDGuide_step GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDGuide_step", key));
				return null;
			}
		}
	}
}