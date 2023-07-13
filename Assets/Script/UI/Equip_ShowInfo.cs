using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Equip_ShowInfo : MonoBehaviour
{
    [Header("�̸�"), SerializeField]
    TextMeshProUGUI NameText;
    [Header("��Ÿ����"), SerializeField]
    TextMeshProUGUI StarposText;
    [Header("���ݷ�"), SerializeField]
    TextMeshProUGUI AttText;
    [Header("ü��"), SerializeField]
    TextMeshProUGUI HpText;
    [Header("����"), SerializeField]
    TextMeshProUGUI DefText;
    [Header("ũ��Ƽ��Ȯ��"), SerializeField]
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
