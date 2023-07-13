using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterSlot : MonoBehaviour
{
    [Header("케릭터 이름"), SerializeField]
    TextMeshProUGUI nameText;
    [Header("케릭터 레벨"), SerializeField]
    TextMeshProUGUI LvText;
    [Header("케릭터 공격력"), SerializeField]
    TextMeshProUGUI AttText;
    [Header("케릭터 방어력"), SerializeField]
    TextMeshProUGUI DefText;
    [Header("케릭터 크리티컬확률"), SerializeField]
    TextMeshProUGUI CrtText;
    [Header("케릭터 체력"), SerializeField]
    TextMeshProUGUI HpText;
    [Header("별"), SerializeField]
    GameObject[] Stars;



    public void SetCharacter(Character character)
    {
        nameText.text = character.Name;
        LvText.text = "Lv. " + character.Level;
        AttText.text = "공격력 : " + character.ATT;
        DefText.text = "방어력 : " + character.DEF;
        CrtText.text="크리티컬 확률 : "+character.Crt + "%";
        HpText.text = "체력 : " + character.MaxHp;
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
