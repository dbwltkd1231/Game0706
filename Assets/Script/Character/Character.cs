using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Character_",menuName ="Character")]
public class Character : ScriptableObject
{
    public LobyCharacter CharacterPrefab;
    public Sprite LobyImage;
    public int ID;

    public string Name;
    public int Level;
    public int Grade;


    public int ATT;
    public int DEF;
    public int MaxHp;
    public int Crt;

    int ItemAtt;
    int itemDef;
    int itemMaxHp;
    int itemCrt;
    

    public Armor myArmor;
    public Pants myPants;
    public Hat myHat;
    public Belt myBelt;
    public Ring myRing;
    public Earrings myEarrings;
    public Bracelet myBracelet;

    public List<Item> EquipItemList;

    public void EquipItem(Item item)
    {
        ItemAtt += item.Item_Att;
        itemDef += item.Item_Def;
        itemMaxHp += item.Item_Hp;
        itemCrt += item.Item_Crt;
        EquipItemList.Add(item);
    }


    //게임플레이 + 로비 모두에 담겨야하는 정보들

    /*
     별개수는 고정
    레벨만 올라가는식
    스탯은? 레벨에 따라올라감 ->데이터화
     */

}
