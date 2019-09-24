using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDGuide_step 
	{
		private int m_Id;
		/// <summary>
		/// ID
		 ///</summary>
		public int Id
		{
			get
			{
				return m_Id;
			}
		}
		private int m_GuideID;
		/// <summary>
		/// GuideID
		 ///</summary>
		public int GuideID
		{
			get
			{
				return m_GuideID;
			}
		}
		private string m_Trigger;
		/// <summary>
		/// Trigger
		 ///</summary>
		public string Trigger
		{
			get
			{
				return m_Trigger;
			}
		}
		private string m_Command;
		/// <summary>
		/// Command
		 ///</summary>
		public string Command
		{
			get
			{
				return m_Command;
			}
		}
		private string m_CommonParam;
		/// <summary>
		/// CommonParam
		 ///</summary>
		public string CommonParam
		{
			get
			{
				return m_CommonParam;
			}
		}
		private int m_RequireStepId;
		/// <summary>
		/// RequireStepId
		 ///</summary>
		public int RequireStepId
		{
			get
			{
				return m_RequireStepId;
			}
		}
		private bool m_KeyFrame;
		/// <summary>
		/// KeyFrame
		 ///</summary>
		public bool KeyFrame
		{
			get
			{
				return m_KeyFrame;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(7);
			ret.Add("Id", 0);
			ret.Add("GuideID", 1);
			ret.Add("Trigger", 2);
			ret.Add("Command", 3);
			ret.Add("CommonParam", 4);
			ret.Add("RequireStepId", 5);
			ret.Add("KeyFrame", 6);
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
	m_GuideID = int.Parse(value);
		break;
case 2:
	m_Trigger = value;
		break;
case 3:
	m_Command = value;
		break;
case 4:
	m_CommonParam = value;
		break;
case 5:
	m_RequireStepId = int.Parse(value);
		break;
case 6:
	m_KeyFrame = value.ToLower().Equals("true");
		break;
default:
	break;
}
}
}
}
}
}