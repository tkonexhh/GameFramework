using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDAd_placement 
	{
public string Id { get; set; }    //ID
	  public string _Id (){
		string value = Id;
		return value;
	}
	public string AdInterface0 { get; set; }    //广告组
	  public string _AdInterface0 (){
		string value = AdInterface0;
		return value;
	}
	public string AdInterface1 { get; set; }    //广告组
	  public string _AdInterface1 (){
		string value = AdInterface1;
		return value;
	}
	public string IsEnable { get; set; }    //是否开启
	public string RewardWhenDisable { get; set; }    //奖励方式
	public string DisplayPrecent { get; set; }    //展示百分比
	public int _DisplayPrecent (){
		int value = int.Parse(DisplayPrecent);
		return value;
	}
	public string TimeInterval { get; set; }    //时间间隔
	public int _TimeInterval (){
		int value = int.Parse(TimeInterval);
		return value;
	}
	public string TimeIntervalGroup { get; set; }    //时间间隔记录组
	public int _TimeIntervalGroup (){
		int value = int.Parse(TimeIntervalGroup);
		return value;
	}
	public string MaxWaitTime { get; set; }    //最大等待时间
	public int _MaxWaitTime (){
		int value = int.Parse(MaxWaitTime);
		return value;
	}
		}
}