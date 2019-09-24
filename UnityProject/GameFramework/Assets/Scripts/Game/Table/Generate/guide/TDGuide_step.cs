using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDGuide_step 
	{
public string Id { get; set; }    //ID
	public int _Id (){
		int value = int.Parse(Id);
		return value;
	}
	public string GuideID { get; set; }    //GuideID
	public int _GuideID (){
		int value = int.Parse(GuideID);
		return value;
	}
	public string Trigger { get; set; }    //Trigger
	  public string _Trigger (){
		string value = Trigger;
		return value;
	}
	public string Command { get; set; }    //Command
	  public string _Command (){
		string value = Command;
		return value;
	}
	public string CommonParam { get; set; }    //CommonParam
	  public string _CommonParam (){
		string value = CommonParam;
		return value;
	}
	public string RequireStepId { get; set; }    //RequireStepId
	public int _RequireStepId (){
		int value = int.Parse(RequireStepId);
		return value;
	}
	public string KeyFrame { get; set; }    //KeyFrame
		}
}