using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Starpos : MonoBehaviour
{
    [Header("������ ������"), SerializeField]
    Image ItemIcon;
    [Header("������ �̸� �ؽ�Ʈ"), SerializeField]
    TextMeshProUGUI NameText;
    [Header("���� ��ȭ ��ġ �ؽ�Ʈ"), SerializeField]
    TextMeshProUGUI CurrentStarposText;
    [Header("���� ������ ���� �ؽ�Ʈ"), SerializeField]
    TextMeshProUGUI CurrentItemStat;
    [Header("���� ������ ��ȭ �ʿ� ���"), SerializeField]
    TextMeshProUGUI ReqStarposGold;
    [Header("���� ������ ��ȭ ���� Ȯ��"), SerializeField]
    TextMeshProUGUI SuccessRate;

    [Header("��ȭ ���� ��ƼŬ"), SerializeField]
    ParticleSystem[] StartParticles;
    [Header("��ȭ ���� ��ƼŬ"), SerializeField]
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
        SuccessRate.text = "��ȭ ���� Ȯ�� : "+successrate + "%";
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
