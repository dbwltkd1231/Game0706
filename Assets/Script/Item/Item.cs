using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int Item_ID;
    public string Item_Name;
    public ItemType Item_Type;
    public ItemDetailType Item_DetailType;
    public Sprite Item_Sprite;
    public string Item_Sprite_Path;
    public int Item_Stat;
    public int Item_Cost;
    public int Item_SetNum;
    public int Item_Starpos;
    public int Item_ReqLv;
    public string Item_Des;



}
public enum ItemType
{
    None,
    장비,
    기타
}
public enum ItemDetailType
{
    상의=0,
    하의,
    모자,
    Boots,
    Earing,
    Belt
}