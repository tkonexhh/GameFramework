using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDFlop 
	{
		private int m_Id;
		/// <summary>
		/// 转盘的位置
		 ///</summary>
		public int Id
		{
			get
			{
				return m_Id;
			}
		}
		private int m_Type;
		/// <summary>
		/// 参数(0-cash 1-Token 2)
		 ///</summary>
		public int Type
		{
			get
			{
				return m_Type;
			}
		}
		private float m_Num;
		/// <summary>
		/// num
		 ///</summary>
		public float Num
		{
			get
			{
				return m_Num;
			}
		}
		private string m_Icon;
		/// <summary>
		/// Icon
		 ///</summary>
		public string Icon
		{
			get
			{
				return m_Icon;
			}
		}
		private int m_Group;
		/// <summary>
		/// Group(0--正常 1--hack拿不到)zheng chang
		 ///</summary>
		public int Group
		{
			get
			{
				return m_Group;
			}
		}
		private int m_Rate;
		/// <summary>
		/// Rate概率
		 ///</summary>
		public int Rate
		{
			get
			{
				return m_Rate;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(6);
			ret.Add("Id", 0);
			ret.Add("Type", 1);
			ret.Add("Num", 2);
			ret.Add("Icon", 3);
			ret.Add("Group", 4);
			ret.Add("Rate", 5);
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
	m_Type = int.Parse(value);
		break;
case 2:
	m_Num = float.Parse(value);
		break;
case 3:
	m_Icon = value;
		break;
case 4:
	m_Group = int.Parse(value);
		break;
case 5:
	m_Rate = int.Parse(value);
		break;
default:
	break;
}
}
}
}
}
}