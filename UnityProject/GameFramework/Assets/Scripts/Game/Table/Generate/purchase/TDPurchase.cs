using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDPurchase 
	{
public string Id { get; set; }    //ID
	  public string _Id (){
		string value = Id;
		return value;
	}
	public string ItemID { get; set; }    //类型
	public int _ItemID (){
		int value = int.Parse(ItemID);
		return value;
	}
	public string PurchaseState { get; set; }    //商品推荐
	public int _PurchaseState (){
		int value = int.Parse(PurchaseState);
		return value;
	}
	public string IsConsume { get; set; }    //是不是消耗品
	public string Price { get; set; }    //价格
	public int _Price (){
		int value = int.Parse(Price);
		return value;
	}
	public string ProductType { get; set; }    //ProductType
	public int _ProductType (){
		int value = int.Parse(ProductType);
		return value;
	}
	public string ServiceKey { get; set; }    //购买服务
	  public string _ServiceKey (){
		string value = ServiceKey;
		return value;
	}
	public string ItemNum { get; set; }    //购买数量
	public int _ItemNum (){
		int value = int.Parse(ItemNum);
		return value;
	}
	public string IOSKey { get; set; }    //苹果ID
	  public string _IOSKey (){
		string value = IOSKey;
		return value;
	}
	public string AndroidKey { get; set; }    //安卓ID
	  public string _AndroidKey (){
		string value = AndroidKey;
		return value;
	}
	public string ItemIcon { get; set; }    //商品Icon
	  public string _ItemIcon (){
		string value = ItemIcon;
		return value;
	}
		}
}