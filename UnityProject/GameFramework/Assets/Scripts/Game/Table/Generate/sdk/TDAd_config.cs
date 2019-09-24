using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDAd_config 
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
		private int m_AdType;
		/// <summary>
		/// 广告类型
		 ///</summary>
		public int AdType
		{
			get
			{
				return m_AdType;
			}
		}
		private string m_AdInterface;
		/// <summary>
		/// AdInterface
		 ///</summary>
		public string AdInterface
		{
			get
			{
				return m_AdInterface;
			}
		}
		private string m_AdPlatform;
		/// <summary>
		/// AdPlatform
		 ///</summary>
		public string AdPlatform
		{
			get
			{
				return m_AdPlatform;
			}
		}
		private int m_Ecpm;
		/// <summary>
		/// eCpm
		 ///</summary>
		public int Ecpm
		{
			get
			{
				return m_Ecpm;
			}
		}
		private string m_UnitIDAndroid;
		/// <summary>
		/// UnitIDAndroid
		 ///</summary>
		public string UnitIDAndroid
		{
			get
			{
				return m_UnitIDAndroid;
			}
		}
		private string m_UnitIDIos;
		/// <summary>
		/// UnitIDIos
		 ///</summary>
		public string UnitIDIos
		{
			get
			{
				return m_UnitIDIos;
			}
		}
		private string m_Keyword;
		/// <summary>
		/// Keyword
		 ///</summary>
		public string Keyword
		{
			get
			{
				return m_Keyword;
			}
		}
		private int m_Gender;
		/// <summary>
		/// Gender
		 ///</summary>
		public int Gender
		{
			get
			{
				return m_Gender;
			}
		}
		private string m_Birthday;
		/// <summary>
		/// Birthday
		 ///</summary>
		public string Birthday
		{
			get
			{
				return m_Birthday;
			}
		}
		private bool m_ForFamilies;
		/// <summary>
		/// ForFamilies
		 ///</summary>
		public bool ForFamilies
		{
			get
			{
				return m_ForFamilies;
			}
		}
		private bool m_ForChild;
		/// <summary>
		/// ForChild
		 ///</summary>
		public bool ForChild
		{
			get
			{
				return m_ForChild;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(12);
			ret.Add("Id", 0);
			ret.Add("AdType", 1);
			ret.Add("AdInterface", 2);
			ret.Add("AdPlatform", 3);
			ret.Add("Ecpm", 4);
			ret.Add("UnitIDAndroid", 5);
			ret.Add("UnitIDIos", 6);
			ret.Add("Keyword", 7);
			ret.Add("Gender", 8);
			ret.Add("Birthday", 9);
			ret.Add("ForFamilies", 10);
			ret.Add("ForChild", 11);
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
	m_AdType = int.Parse(value);
		break;
case 2:
	m_AdInterface = value;
		break;
case 3:
	m_AdPlatform = value;
		break;
case 4:
	m_Ecpm = int.Parse(value);
		break;
case 5:
	m_UnitIDAndroid = value;
		break;
case 6:
	m_UnitIDIos = value;
		break;
case 7:
	m_Keyword = value;
		break;
case 8:
	m_Gender = int.Parse(value);
		break;
case 9:
	m_Birthday = value;
		break;
case 10:
	m_ForFamilies = value.ToLower().Equals("true");
		break;
case 11:
	m_ForChild = value.ToLower().Equals("true");
		break;
default:
	break;
}
}
}
}
}
}