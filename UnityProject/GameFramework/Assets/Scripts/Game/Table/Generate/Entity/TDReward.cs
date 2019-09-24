using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDReward 
	{
public string Id { get; set; }    //兑换IDdui huan
	public int _Id (){
		int value = int.Parse(Id);
		return value;
	}
	public string Img_bg { get; set; }    //图片tu p
	  public string _Img_bg (){
		string value = Img_bg;
		return value;
	}
	public string Price { get; set; }    //价值jia zhi
	public int _Price (){
		int value = int.Parse(Price);
		return value;
	}
	public string NeedTokens { get; set; }    //Tokens
	public int _NeedTokens (){
		int value = int.Parse(NeedTokens);
		return value;
	}
		}
}