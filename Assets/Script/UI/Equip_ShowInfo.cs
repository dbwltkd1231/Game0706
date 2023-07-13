using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Equip_ShowInfo : MonoBehaviour
{
    [Header("이름"), SerializeField]
    TextMeshProUGUI NameText;
    [Header("스타포스"), SerializeField]
    TextMeshProUGUI StarposText;
    [Header("공격력"), SerializeField]
    TextMeshProUGUI AttText;
    [Header("체력"), SerializeField]
    TextMeshProUGUI HpText;
    [Header("방어력"), SerializeField]
    TextMeshProUGUI DefText;
    [Header("크리티컬확률"), SerializeField]
    TextMeshProUGUI CrtText;

    Item myItem;

    public void getItem(Item item)
    {
        myItem = item;
        NameText.text = myItem.Item_Name;
        StarposText.text = "+" + myItem.Item_Starpos;
        AttText.text = "+" + myItem.Item_Att;
        HpText.text = "+" + myItem.Item_Hp;
        DefText.text = "+" + myItem.Item_Def;
        CrtText.text = "+" + myItem.Item_Crt + "%";
    }
}
