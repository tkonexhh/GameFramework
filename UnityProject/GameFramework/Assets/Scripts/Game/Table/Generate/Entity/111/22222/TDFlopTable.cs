using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDFlopTable
	{
		private static Dictionary<int, TDFlop> m_DataCache = new Dictionary<int, TDFlop>();
		private static List<TDFlop> m_DataList = new List<TDFlop>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDFlop> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDFlop GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDFlop", key));
				return null;
			}
		}
	}
}