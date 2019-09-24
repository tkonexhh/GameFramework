using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDWheelTable
	{
		private static Dictionary<int, TDWheel> m_DataCache = new Dictionary<int, TDWheel>();
		private static List<TDWheel> m_DataList = new List<TDWheel>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDWheel> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDWheel GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDWheel", key));
				return null;
			}
		}
	}
}