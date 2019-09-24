using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDReward 
	{
		private int m_Id;
		/// <summary>
		/// 兑换IDdui huan
		 ///</summary>
		public int Id
		{
			get
			{
				return m_Id;
			}
		}
		private string m_Img_bg;
		/// <summary>
		/// 图片tu p
		 ///</summary>
		public string Img_bg
		{
			get
			{
				return m_Img_bg;
			}
		}
		private int m_Price;
		/// <summary>
		/// 价值jia zhi
		 ///</summary>
		public int Price
		{
			get
			{
				return m_Price;
			}
		}
		private int m_NeedTokens;
		/// <summary>
		/// Tokens
		 ///</summary>
		public int NeedTokens
		{
			get
			{
				return m_NeedTokens;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(4);
			ret.Add("Id", 0);
			ret.Add("Img_bg", 1);
			ret.Add("Price", 2);
			ret.Add("NeedTokens", 3);
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
	m_Id = int.Parse(value);
		break;
case 1:
	m_Img_bg = value;
		break;
case 2:
	m_Price = int.Parse(value);
		break;
case 3:
	m_NeedTokens = int.Parse(value);
		break;
default:
	break;
}
}
}
}
}
}