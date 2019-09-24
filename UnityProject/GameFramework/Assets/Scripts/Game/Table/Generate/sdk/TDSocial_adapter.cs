using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDSocial_adapter 
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
		private string m_Param1;
		/// <summary>
		/// 平台场景ID
		 ///</summary>
		public string Param1
		{
			get
			{
				return m_Param1;
			}
		}
		private string m_Param2;
		/// <summary>
		/// 平台场景ID
		 ///</summary>
		public string Param2
		{
			get
			{
				return m_Param2;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(3);
			ret.Add("Id", 0);
			ret.Add("Param1", 1);
			ret.Add("Param2", 2);
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
	m_Param1 = value;
		break;
case 2:
	m_Param2 = value;
		break;
default:
	break;
}
}
}
}
}
}