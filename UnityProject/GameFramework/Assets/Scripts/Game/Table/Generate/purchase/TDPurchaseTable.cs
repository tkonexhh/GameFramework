using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDPurchaseTable
	{
		private static Dictionary<string, TDPurchase> m_DataCache = new Dictionary<string, TDPurchase>();
		private static List<TDPurchase> m_DataList = new List<TDPurchase>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDPurchase> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDPurchase GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDPurchase", key));
				return null;
			}
		}
	}
}