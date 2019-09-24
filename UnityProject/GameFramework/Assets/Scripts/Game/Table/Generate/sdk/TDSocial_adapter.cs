using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDSocial_adapter 
	{
public string Id { get; set; }    //ID
	  public string _Id (){
		string value = Id;
		return value;
	}
	public string Param1 { get; set; }    //平台场景ID
	  public string _Param1 (){
		string value = Param1;
		return value;
	}
	public string Param2 { get; set; }    //平台场景ID
	  public string _Param2 (){
		string value = Param2;
		return value;
	}
		}
}