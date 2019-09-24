using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDGuide 
	{
public string Id { get; set; }    //ID
	public int _Id (){
		int value = int.Parse(Id);
		return value;
	}
	public string Trigger { get; set; }    //Trigger
	  public string _Trigger (){
		string value = Trigger;
		return value;
	}
	public string CommonParam { get; set; }    //CommonParam
	  public string _CommonParam (){
		string value = CommonParam;
		return value;
	}
	public string RequireGuideId { get; set; }    //RequireGuideId
	public int _RequireGuideId (){
		int value = int.Parse(RequireGuideId);
		return value;
	}
	public string JumpTrigger { get; set; }    //JumpTrigger
	  public string _JumpTrigger (){
		string value = JumpTrigger;
		return value;
	}
		}
}