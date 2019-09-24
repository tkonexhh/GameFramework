using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDFlop 
	{
public string Id { get; set; }    //转盘的位置
	public int _Id (){
		int value = int.Parse(Id);
		return value;
	}
	public string Type { get; set; }    //参数(0-cash 1-Token 2)
	public int _Type (){
		int value = int.Parse(Type);
		return value;
	}
	public string Num { get; set; }    //num
	  public float _Num (){
		float value = float.Parse(Num);
		return value;
	}
	public string Icon { get; set; }    //Icon
	  public string _Icon (){
		string value = Icon;
		return value;
	}
	public string Group { get; set; }    //Group(0--正常 1--hack拿不到)zheng chang
	public int _Group (){
		int value = int.Parse(Group);
		return value;
	}
	public string Rate { get; set; }    //Rate概率
	public int _Rate (){
		int value = int.Parse(Rate);
		return value;
	}
		}
}