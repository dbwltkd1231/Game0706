using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Starpos : MonoBehaviour
{
    [Header("아이템 아이콘"), SerializeField]
    Image ItemIcon;
    [Header("아이템 이름 텍스트"), SerializeField]
    TextMeshProUGUI NameText;
    [Header("현재 강화 수치 텍스트"), SerializeField]
    TextMeshProUGUI CurrentStarposText;
    [Header("현재 아이템 스탯 텍스트"), SerializeField]
    TextMeshProUGUI CurrentItemStat;
    [Header("현재 아이템 강화 필요 골드"), SerializeField]
    TextMeshProUGUI ReqStarposGold;
    [Header("현재 아이템 강화 성공 확률"), SerializeField]
    TextMeshProUGUI SuccessRate;

    [Header("강화 시작 파티클"), SerializeField]
    ParticleSystem[] StartParticles;
    [Header("강화 성공 파티클"), SerializeField]
    ParticleSystem[] SuccessParticles;
    Item myitem;

    int successrate;
    int ReqGold;
    bool Ing;
    public void GetItem(Item item)
    {
        myitem = item;
        ItemIcon.sprite = myitem.Item_Sprite;
        NameText.text = myitem.Item_Name;
        CurrentStarposText.text = ": +" + myitem.Item_Starpos;
        ReqGold = (myitem.Item_Cost / 100 * (myitem.Item_Starpos + 1));
        ReqStarposGold.text = ReqGold.ToString();

        successrate = (10 - myitem.Item_Starpos)*10;
        if(successrate<10)
        {
            successrate = 10;
        }
        SuccessRate.text = "강화 성공 확률 : "+successrate + "%";
    }
    public void StarposStart()
    {
        if(Ing==false)
        {
            Ing = true;
            StartCoroutine(starpos());
        }
    }
    IEnumerator starpos()
    {
        int randomvalue = Random.Range(0, 100);


        for(int i=0;i< StartParticles.Length;i++)
        {
            StartParticles[i].Play();
        }
        
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < StartParticles.Length; i++)
        {
            StartParticles[i].Stop();
        }
        if (randomvalue < successrate)
        {
            myitem.Item_Starpos++;
            for (int i = 0; i < SuccessParticles.Length; i++)
            {
                SuccessParticles[i].Play();
            }
        }
        else
        {
            myitem.Item_Starpos = --myitem.Item_Starpos < 0 ? 0 : --myitem.Item_Starpos;
        }
        
        GetItem(myitem);
        Ing = false;
    }
}
