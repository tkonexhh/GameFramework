using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDTest 
	{
		private int m_A;
		/// <summary>
		/// 123
		 ///</summary>
		public int A
		{
			get
			{
				return m_A;
			}
		}
		private int m_B;
		/// <summary>
		/// 1231
		 ///</summary>
		public int B
		{
			get
			{
				return m_B;
			}
		}
		private int m_C;
		/// <summary>
		/// 123
		 ///</summary>
		public int C
		{
			get
			{
				return m_C;
			}
		}
		private int m_D;
		/// <summary>
		/// 123
		 ///</summary>
		public int D
		{
			get
			{
				return m_D;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(4);
			ret.Add("A", 0);
			ret.Add("B", 1);
			ret.Add("C", 2);
			ret.Add("D", 3);
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
	m_A = int.Parse(value);
		break;
case 1:
	m_B = int.Parse(value);
		break;
case 2:
	m_C = int.Parse(value);
		break;
case 3:
	m_D = int.Parse(value);
		break;
default:
	break;
}
}
}
}
}
}