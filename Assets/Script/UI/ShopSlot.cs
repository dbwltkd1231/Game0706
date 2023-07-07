using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI ItemName;
    [SerializeField]
    Image ItemImg;
    [SerializeField]
    TextMeshProUGUI itemCost;
    Item myItem;

    public void getItem(Item newItem)
    {
        myItem = newItem;
        ItemName.text = myItem.Item_Name;
        ItemImg.sprite = myItem.Item_Sprite;
        itemCost.text = myItem.Item_Cost.ToString();
    }



}
