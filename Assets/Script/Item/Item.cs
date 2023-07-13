using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Item
{
    public int Item_ID;
    public string Item_Name;
    public ItemType Item_Type;
    public ItemDetailType Item_DetailType;
    public Sprite Item_Sprite;
    public string Item_Sprite_Path;
    public int Item_Cost;
    public int Item_SetNum;
    public int Item_Starpos;
    public int Item_ReqLv;
    public string Item_Des;


    public int Item_Att;
    public int Item_Hp;
    public int Item_Def;
    public int Item_Crt;
    public virtual void ItemEffect()
    {

    }



    public string Item_StatType()
    {
        if (Item_DetailType.ToString() == "Armor")
        {
            return "체력";
        }
        else if (Item_DetailType.ToString() == "Pants")
        {
            return "체력";
        }
        else if (Item_DetailType.ToString() == "Hat")
        {
            return "체력";
        }
        else if (Item_DetailType.ToString() == "Belt")
        {
            return "방어력";
        }
        else if (Item_DetailType.ToString() == "Earrings")
        {
            return "방어력";
        }
        else if (Item_DetailType.ToString() == "Ring")
        {
            return "공격력";
        }
        else if (Item_DetailType.ToString() == "Bracelet")
        {
            return "공격력";
        }
        else
        {
            return string.Empty;
        }


    }

 



}
public enum ItemType
{
    None,
    장비,
    악세서리
}
public enum ItemDetailType
{
    Armor=0,
    Pants,
    Hat,
    Belt,
    Earrings,
    Ring,
    Bracelet
}