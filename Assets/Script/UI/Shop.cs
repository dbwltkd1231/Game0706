using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [Header("아이템데이터 저장경로"), SerializeField]
    string csv_FileName;
    

    [Header("장비 스크롤 뷰"), SerializeField]
    Transform EquipContent;
    [Header("악세서리 스크롤 뷰"), SerializeField]
    Transform AccContent;
    [Header("기타 스크롤 뷰"), SerializeField]
    Transform EtcContent;
    [Header("상점 슬롯 프리팹"), SerializeField]
    GameObject SlotPrefab;
    [Header("장비 상점"), SerializeField]
    GameObject EquipShop;
    [Header("소비 상점"), SerializeField]
    GameObject UseShop;
    [Header("기타 상점"), SerializeField]
    GameObject EtcShop;



    List<Item> EquiptemList;
    List<Item> AccItemList;
    Queue<GameObject> slotQueue;
    GameObject currentView;

    private void Start()
    {
        slotQueue = ObjectPooling.Instance.CreateQueue();
        EquiptemList = new List<Item>();
        AccItemList = new List<Item>();
        CreateItem(csv_FileName);
        init();


    }
   
    private void init()
    {
        for(int i=0;i< EquiptemList.Count;i++)
        {
            GameObject newSlot = ObjectPooling.Instance.CreatePoolObj(slotQueue, EquipContent, SlotPrefab);
            newSlot.GetComponent<ShopSlot>().getItem(EquiptemList[i]);
            newSlot.SetActive(true);
        }
        for (int i = 0; i < AccItemList.Count; i++)
        {
            GameObject newSlot = ObjectPooling.Instance.CreatePoolObj(slotQueue, AccContent, SlotPrefab);
            newSlot.GetComponent<ShopSlot>().getItem(AccItemList[i]);
            newSlot.SetActive(true);
        }

    }

   
   public void OpenView(GameObject SelectShop)
    {
        if(currentView!=null)
        {
            currentView.SetActive(false);
        }
       
        currentView = SelectShop;
        currentView.SetActive(true);
    }

    public void CreateItem(string _CSVFileName)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(_CSVFileName);

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["ID"] == string.Empty)
            {
                break;
            }
            
            Item newItem = new Item();
            newItem.Item_ID = (int)data[i]["ID"];
            newItem.Item_Name = data[i]["이름"].ToString();
            newItem.Item_Type = (ItemType)(Enum.Parse(typeof(ItemType), data[i]["타입"].ToString()));
            newItem.Item_DetailType = (ItemDetailType)(Enum.Parse(typeof(ItemDetailType), data[i]["세부타입"].ToString()));
            newItem.Item_Sprite_Path = data[i]["이미지"].ToString();
            newItem.Item_Sprite = Resources.Load<Sprite>(newItem.Item_Sprite_Path);
            newItem.Item_Stat = (int)data[i]["스탯"];
            newItem.Item_Cost = (int)data[i]["가격"];
            newItem.Item_SetNum = (int)data[i]["세트번호"];
            newItem.Item_Cost = (int)data[i]["가격"];
            newItem.Item_Starpos = (int)data[i]["강화수치"];
            newItem.Item_ReqLv = (int)data[i]["요구레벨"];
            newItem.Item_Des = data[i]["설명"].ToString();
           
            if(newItem.Item_Type.ToString()=="장비")
            {
                EquiptemList.Add(newItem);
            }
            else if (newItem.Item_Type.ToString() == "악세서리")
            {
                AccItemList.Add(newItem);
            }


        }

    }
}
