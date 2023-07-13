using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterSlot : MonoBehaviour
{
    [Header("�ɸ��� �̸�"), SerializeField]
    TextMeshProUGUI nameText;
    [Header("�ɸ��� ����"), SerializeField]
    TextMeshProUGUI LvText;
    [Header("�ɸ��� ���ݷ�"), SerializeField]
    TextMeshProUGUI AttText;
    [Header("�ɸ��� ����"), SerializeField]
    TextMeshProUGUI DefText;
    [Header("�ɸ��� ũ��Ƽ��Ȯ��"), SerializeField]
    TextMeshProUGUI CrtText;
    [Header("�ɸ��� ü��"), SerializeField]
    TextMeshProUGUI HpText;
    [Header("��"), SerializeField]
    GameObject[] Stars;



    public void SetCharacter(Character character)
    {
        nameText.text = character.Name;
        LvText.text = "Lv. " + character.Level;
        AttText.text = "���ݷ� : " + character.ATT;
        DefText.text = "���� : " + character.DEF;
        CrtText.text="ũ��Ƽ�� Ȯ�� : "+character.Crt + "%";
        HpText.text = "ü�� : " + character.MaxHp;
        setStars(character.Grade);

    }
    void setStars(int starNum)
    {
        int i = 0;
        for (;i< starNum;i++)
        {
            Stars[i].SetActive(true);
        }
        for(;i<Stars.Length;i++)
        {
            Stars[i].SetActive(false);
        }
    }

}
