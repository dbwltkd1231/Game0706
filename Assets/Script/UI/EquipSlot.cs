using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [SerializeField]
    Image itemImage;
    [SerializeField]
    public ItemDetailType SlotType;

    public Item SlotItem;
    
    
    public void getItem(Item item)
    {
        Color color = itemImage.GetComponent<Image>().color;
        color.a = 1f;
        itemImage.GetComponent<Image>().color = color;

        SlotItem = item;
        itemImage.sprite = SlotItem.Item_Sprite;
        
    }
    public void removeItem()
    {
        Color color = itemImage.GetComponent<Image>().color;
        color.a = 0f;
        itemImage.GetComponent<Image>().color = color;

        itemImage.sprite = null;
        SlotItem = null;
    }
}
