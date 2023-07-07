using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [Header("�����۵����� ������"), SerializeField]
    string csv_FileName;
    

    [Header("��� ��ũ�� ��"), SerializeField]
    Transform EquipContent;
    [Header("�Ǽ����� ��ũ�� ��"), SerializeField]
    Transform AccContent;
    [Header("��Ÿ ��ũ�� ��"), SerializeField]
    Transform EtcContent;
    [Header("���� ���� ������"), SerializeField]
    GameObject SlotPrefab;
    [Header("��� ����"), SerializeField]
    GameObject EquipShop;
    [Header("�Һ� ����"), SerializeField]
    GameObject UseShop;
    [Header("��Ÿ ����"), SerializeField]
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
            newItem.Item_Name = data[i]["�̸�"].ToString();
            newItem.Item_Type = (ItemType)(Enum.Parse(typeof(ItemType), data[i]["Ÿ��"].ToString()));
            newItem.Item_DetailType = (ItemDetailType)(Enum.Parse(typeof(ItemDetailType), data[i]["����Ÿ��"].ToString()));
            newItem.Item_Sprite_Path = data[i]["�̹���"].ToString();
            newItem.Item_Sprite = Resources.Load<Sprite>(newItem.Item_Sprite_Path);
            newItem.Item_Stat = (int)data[i]["����"];
            newItem.Item_Cost = (int)data[i]["����"];
            newItem.Item_SetNum = (int)data[i]["��Ʈ��ȣ"];
            newItem.Item_Cost = (int)data[i]["����"];
            newItem.Item_Starpos = (int)data[i]["��ȭ��ġ"];
            newItem.Item_ReqLv = (int)data[i]["�䱸����"];
            newItem.Item_Des = data[i]["����"].ToString();
           
            if(newItem.Item_Type.ToString()=="���")
            {
                EquiptemList.Add(newItem);
            }
            else if (newItem.Item_Type.ToString() == "�Ǽ�����")
            {
                AccItemList.Add(newItem);
            }


        }

    }
}
