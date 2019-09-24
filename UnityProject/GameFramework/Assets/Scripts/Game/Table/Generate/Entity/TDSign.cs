using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDSign 
	{
public string Id { get; set; }    //Day
	public int _Id (){
		int value = int.Parse(Id);
		return value;
	}
	public string Type { get; set; }    //Type(0-cash 1-Token)
	public int _Type (){
		int value = int.Parse(Type);
		return value;
	}
	public string Num { get; set; }    //num
	public int _Num (){
		int value = int.Parse(Num);
		return value;
	}
		}
}