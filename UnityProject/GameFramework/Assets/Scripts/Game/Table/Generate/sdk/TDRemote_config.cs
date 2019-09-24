using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDRemote_config 
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
		private string m_Value;
		/// <summary>
		/// 参数
		 ///</summary>
		public string Value
		{
			get
			{
				return m_Value;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(2);
			ret.Add("Id", 0);
			ret.Add("Value", 1);
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
	m_Value = value;
		break;
default:
	break;
}
}
}
}
}
}