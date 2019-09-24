using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDAsdtTable
	{
		private static Dictionary<int, TDAsdt> m_DataCache = new Dictionary<int, TDAsdt>();
		private static List<TDAsdt> m_DataList = new List<TDAsdt>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDAsdt> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDAsdt GetData(int key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDAsdt", key));
				return null;
			}
		}
	}
}