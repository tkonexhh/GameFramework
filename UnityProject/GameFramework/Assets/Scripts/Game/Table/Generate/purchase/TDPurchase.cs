using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDPurchase 
	{
		private string m_Id;
		/// <summary>
		/// ID
		 ///</summary>
		public string Id
		{
			get
			{
				return m_Id;
			}
		}
		private int m_ItemID;
		/// <summary>
		/// 类型
		 ///</summary>
		public int ItemID
		{
			get
			{
				return m_ItemID;
			}
		}
		private int m_PurchaseState;
		/// <summary>
		/// 商品推荐
		 ///</summary>
		public int PurchaseState
		{
			get
			{
				return m_PurchaseState;
			}
		}
		private bool m_IsConsume;
		/// <summary>
		/// 是不是消耗品
		 ///</summary>
		public bool IsConsume
		{
			get
			{
				return m_IsConsume;
			}
		}
		private int m_Price;
		/// <summary>
		/// 价格
		 ///</summary>
		public int Price
		{
			get
			{
				return m_Price;
			}
		}
		private int m_ProductType;
		/// <summary>
		/// ProductType
		 ///</summary>
		public int ProductType
		{
			get
			{
				return m_ProductType;
			}
		}
		private string m_ServiceKey;
		/// <summary>
		/// 购买服务
		 ///</summary>
		public string ServiceKey
		{
			get
			{
				return m_ServiceKey;
			}
		}
		private int m_ItemNum;
		/// <summary>
		/// 购买数量
		 ///</summary>
		public int ItemNum
		{
			get
			{
				return m_ItemNum;
			}
		}
		private string m_IOSKey;
		/// <summary>
		/// 苹果ID
		 ///</summary>
		public string IOSKey
		{
			get
			{
				return m_IOSKey;
			}
		}
		private string m_AndroidKey;
		/// <summary>
		/// 安卓ID
		 ///</summary>
		public string AndroidKey
		{
			get
			{
				return m_AndroidKey;
			}
		}
		private string m_ItemIcon;
		/// <summary>
		/// 商品Icon
		 ///</summary>
		public string ItemIcon
		{
			get
			{
				return m_ItemIcon;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(11);
			ret.Add("Id", 0);
			ret.Add("ItemID", 1);
			ret.Add("PurchaseState", 2);
			ret.Add("IsConsume", 3);
			ret.Add("Price", 4);
			ret.Add("ProductType", 5);
			ret.Add("ServiceKey", 6);
			ret.Add("ItemNum", 7);
			ret.Add("IOSKey", 8);
			ret.Add("AndroidKey", 9);
			ret.Add("ItemIcon", 10);
			return ret;
		}
	public void BindData(Dictionary<string, string> dataMap)
	{
		Dictionary<string, int> headIndexMap = GetFieldHeadIndex();
		foreach (var key in dataMap.Keys)
{
int col = -1;
		string value = dataMap[key];
		if (headIndexMap.TryGetValue(key, out col))
	{
		switch (col)
	{
		case 0:
	m_Id = value;
		break;
case 1:
	m_ItemID = int.Parse(value);
		break;
case 2:
	m_PurchaseState = int.Parse(value);
		break;
case 3:
	m_IsConsume = value.ToLower().Equals("true");
		break;
case 4:
	m_Price = int.Parse(value);
		break;
case 5:
	m_ProductType = int.Parse(value);
		break;
case 6:
	m_ServiceKey = value;
		break;
case 7:
	m_ItemNum = int.Parse(value);
		break;
case 8:
	m_IOSKey = value;
		break;
case 9:
	m_AndroidKey = value;
		break;
case 10:
	m_ItemIcon = value;
		break;
default:
	break;
}
}
}
}
}
}