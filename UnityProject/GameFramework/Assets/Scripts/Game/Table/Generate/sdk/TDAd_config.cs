using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDAd_config 
	{
public string Id { get; set; }    //ID
	  public string _Id (){
		string value = Id;
		return value;
	}
	public string AdType { get; set; }    //广告类型
	public int _AdType (){
		int value = int.Parse(AdType);
		return value;
	}
	public string AdInterface { get; set; }    //AdInterface
	  public string _AdInterface (){
		string value = AdInterface;
		return value;
	}
	public string AdPlatform { get; set; }    //AdPlatform
	  public string _AdPlatform (){
		string value = AdPlatform;
		return value;
	}
	public string Ecpm { get; set; }    //eCpm
	public int _Ecpm (){
		int value = int.Parse(Ecpm);
		return value;
	}
	public string UnitIDAndroid { get; set; }    //UnitIDAndroid
	  public string _UnitIDAndroid (){
		string value = UnitIDAndroid;
		return value;
	}
	public string UnitIDIos { get; set; }    //UnitIDIos
	  public string _UnitIDIos (){
		string value = UnitIDIos;
		return value;
	}
	public string Keyword { get; set; }    //Keyword
	  public string _Keyword (){
		string value = Keyword;
		return value;
	}
	public string Gender { get; set; }    //Gender
	public int _Gender (){
		int value = int.Parse(Gender);
		return value;
	}
	public string Birthday { get; set; }    //Birthday
	  public string _Birthday (){
		string value = Birthday;
		return value;
	}
	public string ForFamilies { get; set; }    //ForFamilies
	public string ForChild { get; set; }    //ForChild
		}
}