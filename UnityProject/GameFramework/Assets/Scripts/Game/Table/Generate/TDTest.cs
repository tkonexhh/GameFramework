using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDTest 
	{
		private string m_A;
		/// <summary>
		/// A
		 ///</summary>
		public string A
		{
			get
			{
				return m_A;
			}
		}
		private List<string> m_B;
		/// <summary>
		/// B
		 ///</summary>
		public List<string> B
		{
			get
			{
				return m_B;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(2);
			ret.Add("A", 0);
			ret.Add("B", 1);
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
							m_A = value;
							break;
						case 1:
							m_B =  Helper.String2ListString(value, ",");
							break;
						default:
							break;
					}
				}
			}
		}
	}
}