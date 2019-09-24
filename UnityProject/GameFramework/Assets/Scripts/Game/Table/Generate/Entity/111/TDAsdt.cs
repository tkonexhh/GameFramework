using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDAsdt 
	{
public string Day { get; set; }    //Day
	public int _Day (){
		int value = int.Parse(Day);
		return value;
	}
	public string Wheel { get; set; }    //wheel
	  public string _Wheel (){
		string value = Wheel;
		return value;
	}
	public string CatchGold { get; set; }    //catchGold现金
	  public string _CatchGold (){
		string value = CatchGold;
		return value;
	}
	public string Flop { get; set; }    //Flop奖励ID
	  public string _Flop (){
		string value = Flop;
		return value;
	}
		}
}