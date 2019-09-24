using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{
	public partial class TDSocial_adapterTable
	{
		private static Dictionary<string, TDSocial_adapter> m_DataCache = new Dictionary<string, TDSocial_adapter>();
		private static List<TDSocial_adapter> m_DataList = new List<TDSocial_adapter>();
		public static int count
		{
			get
			{
				return m_DataCache.Count;
			}
		}
		public static List<TDSocial_adapter> dataList
		{
			get
			{
				return m_DataList;
			}
		}
		public static TDSocial_adapter GetData(string key)
		{
			if (m_DataCache.ContainsKey(key))
			{
				return m_DataCache[key];
			}
			else
			{
				Log.w(string.Format("Can't find key {0} in TDSocial_adapter", key));
				return null;
			}
		}
	}
}