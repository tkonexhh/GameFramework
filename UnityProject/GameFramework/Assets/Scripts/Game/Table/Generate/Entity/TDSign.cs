using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDSign 
	{
		private int m_Id;
		/// <summary>
		/// Day
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
		/// Type(0-cash 1-Token)
		 ///</summary>
		public int Type
		{
			get
			{
				return m_Type;
			}
		}
		private int m_Num;
		/// <summary>
		/// num
		 ///</summary>
		public int Num
		{
			get
			{
				return m_Num;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(3);
			ret.Add("Id", 0);
			ret.Add("Type", 1);
			ret.Add("Num", 2);
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
	m_Num = int.Parse(value);
		break;
default:
	break;
}
}
}
}
}
}