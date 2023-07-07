using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ItemName;
    [SerializeField]
    Image ItemImg;
    [SerializeField]
    public Image FrameImg;

    Item myItem;

    public void getItem(Item newItem)
    {
        myItem = newItem;
        ItemName.text = myItem.Item_Name;
        ItemImg.sprite = myItem.Item_Sprite;
    }
    public Item ReturnItem()
    {
        return myItem;
    }
    public void Select()
    {
        Inventory.Instance.SelectSlot(this);

    }

}
