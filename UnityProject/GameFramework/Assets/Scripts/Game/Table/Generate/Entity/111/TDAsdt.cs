using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDAsdt 
	{
		private int m_Day;
		/// <summary>
		/// Day
		 ///</summary>
		public int Day
		{
			get
			{
				return m_Day;
			}
		}
		private string m_Wheel;
		/// <summary>
		/// wheel
		 ///</summary>
		public string Wheel
		{
			get
			{
				return m_Wheel;
			}
		}
		private string m_CatchGold;
		/// <summary>
		/// catchGold现金
		 ///</summary>
		public string CatchGold
		{
			get
			{
				return m_CatchGold;
			}
		}
		private string m_Flop;
		/// <summary>
		/// Flop奖励ID
		 ///</summary>
		public string Flop
		{
			get
			{
				return m_Flop;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(4);
			ret.Add("Day", 0);
			ret.Add("Wheel", 1);
			ret.Add("CatchGold", 2);
			ret.Add("Flop", 3);
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
	m_Day = int.Parse(value);
		break;
case 1:
	m_Wheel = value;
		break;
case 2:
	m_CatchGold = value;
		break;
case 3:
	m_Flop = value;
		break;
default:
	break;
}
}
}
}
}
}