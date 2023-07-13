using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Equip_InventorySlot : MonoBehaviour
{

    [Header("아이템 이미지"), SerializeField]
    Image itemImage;
    [Header("아이템 이름"), SerializeField]
    TextMeshProUGUI ItemName;
    [Header("아이템 강화수치"), SerializeField]
    TextMeshProUGUI itemStarpos;
    [Header("아이템 요구레벨"), SerializeField]
    TextMeshProUGUI ItemReqLv;
    [Header("아이템 타입"), SerializeField]
    TextMeshProUGUI ItemDetailType;
    [Header("아이템 스탯종류"), SerializeField]
    TextMeshProUGUI ItemStatType;
    [Header("아이템 스탯수치"), SerializeField]
    TextMeshProUGUI ItemStatMag;


    public Item slotItem;


    public void getItem(Item item)
    {
        slotItem = item;
        itemImage.sprite = slotItem.Item_Sprite;
        ItemName.text = slotItem.Item_Name;
        itemStarpos.text = "+" + slotItem.Item_Starpos;
        ItemReqLv.text = "Lv." + slotItem.Item_ReqLv;
        ItemDetailType.text = slotItem.Item_DetailType.ToString();
        ItemStatType.text = slotItem.Item_StatType();

       // ItemStatMag.text = slotItem.Item_Stat.ToString();
    }
    public void EquipItem()
    {
        Equip_Inventory.Instance.EquipItem(this);
    }
    public void ClickSlot()
    {
        Equip_Inventory.Instance.ClickEquipSlots(this);
    }

}
