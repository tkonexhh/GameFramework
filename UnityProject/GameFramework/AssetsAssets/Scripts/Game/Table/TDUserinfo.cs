using UnityEngine; 
using System.Collections; 
using GFrame; 
namespace GameWish.Game 
{ 
public partial class TDUserinfo { 
	public string Id { get; set; }    //ID
	public int _Id (){
		int value = int.Parse(Id);
		return value;
	}
	public string Name { get; set; }    //名字
	  public string _Name (){
		string value = Name;
		return value;
	}
	public string Icon { get; set; }    //资源
	  public string _Icon (){
		string value = Icon;
		return value;
	}
	public string Shortname { get; set; }    //简写
	  public string _Shortname (){
		string value = Shortname;
		return value;
	}
	}
	}