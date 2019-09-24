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
	public static void Parse()
		{
			m_DataCache.Clear();
		m_DataList.Clear();
		List<Dictionary<string, string>> allDataList = SerializeHelper.DeserializeJson<List<Dictionary<string, string>>>(FilePath.streamingAssetsPath4Config + "Purchase.json", false);int count = allDataList.Count;
		for (int i = 0; i < count; i++)
		{
			Dictionary<string, string> dataMap = allDataList[i];
		TDPurchase data = new TDPurchase();
		data.BindData(dataMap);
		m_DataList.Add(data);
		m_DataCache.Add(data.Id, data);
		}
		}
		}
	}