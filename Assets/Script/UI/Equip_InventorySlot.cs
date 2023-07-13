using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Equip_InventorySlot : MonoBehaviour
{

    [Header("������ �̹���"), SerializeField]
    Image itemImage;
    [Header("������ �̸�"), SerializeField]
    TextMeshProUGUI ItemName;
    [Header("������ ��ȭ��ġ"), SerializeField]
    TextMeshProUGUI itemStarpos;
    [Header("������ �䱸����"), SerializeField]
    TextMeshProUGUI ItemReqLv;
    [Header("������ Ÿ��"), SerializeField]
    TextMeshProUGUI ItemDetailType;
    [Header("������ ��������"), SerializeField]
    TextMeshProUGUI ItemStatType;
    [Header("������ ���ȼ�ġ"), SerializeField]
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
