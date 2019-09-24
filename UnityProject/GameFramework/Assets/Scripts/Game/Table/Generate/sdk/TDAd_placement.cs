using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game
{
	public partial class TDAd_placement 
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
		private string m_AdInterface0;
		/// <summary>
		/// 广告组
		 ///</summary>
		public string AdInterface0
		{
			get
			{
				return m_AdInterface0;
			}
		}
		private string m_AdInterface1;
		/// <summary>
		/// 广告组
		 ///</summary>
		public string AdInterface1
		{
			get
			{
				return m_AdInterface1;
			}
		}
		private bool m_IsEnable;
		/// <summary>
		/// 是否开启
		 ///</summary>
		public bool IsEnable
		{
			get
			{
				return m_IsEnable;
			}
		}
		private bool m_RewardWhenDisable;
		/// <summary>
		/// 奖励方式
		 ///</summary>
		public bool RewardWhenDisable
		{
			get
			{
				return m_RewardWhenDisable;
			}
		}
		private int m_DisplayPrecent;
		/// <summary>
		/// 展示百分比
		 ///</summary>
		public int DisplayPrecent
		{
			get
			{
				return m_DisplayPrecent;
			}
		}
		private int m_TimeInterval;
		/// <summary>
		/// 时间间隔
		 ///</summary>
		public int TimeInterval
		{
			get
			{
				return m_TimeInterval;
			}
		}
		private int m_TimeIntervalGroup;
		/// <summary>
		/// 时间间隔记录组
		 ///</summary>
		public int TimeIntervalGroup
		{
			get
			{
				return m_TimeIntervalGroup;
			}
		}
		private int m_MaxWaitTime;
		/// <summary>
		/// 最大等待时间
		 ///</summary>
		public int MaxWaitTime
		{
			get
			{
				return m_MaxWaitTime;
			}
		}
		
		public static Dictionary<string, int> GetFieldHeadIndex()
		{
			Dictionary<string, int> ret = new Dictionary<string, int>(9);
			ret.Add("Id", 0);
			ret.Add("AdInterface0", 1);
			ret.Add("AdInterface1", 2);
			ret.Add("IsEnable", 3);
			ret.Add("RewardWhenDisable", 4);
			ret.Add("DisplayPrecent", 5);
			ret.Add("TimeInterval", 6);
			ret.Add("TimeIntervalGroup", 7);
			ret.Add("MaxWaitTime", 8);
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
	m_AdInterface0 = value;
		break;
case 2:
	m_AdInterface1 = value;
		break;
case 3:
	m_IsEnable = value.ToLower().Equals("true");
		break;
case 4:
	m_RewardWhenDisable = value.ToLower().Equals("true");
		break;
case 5:
	m_DisplayPrecent = int.Parse(value);
		break;
case 6:
	m_TimeInterval = int.Parse(value);
		break;
case 7:
	m_TimeIntervalGroup = int.Parse(value);
		break;
case 8:
	m_MaxWaitTime = int.Parse(value);
		break;
default:
	break;
}
}
}
}
}
}