using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Inventory : MonoBehaviour
{
    public static Equip_Inventory Instance;

    [Header("인벤토리 슬롯 프리팹"), SerializeField]
    Equip_InventorySlot Equip_InventorySlotPrefab;
    [Header("인벤토리 슬롯 트랜스폼"), SerializeField]
    Transform Equip_InventorySlotParent;
    [Header("인벤토리 슬롯 트랜스폼"), SerializeField]
    EquipSlot[] EquipSlots;
    [Header("아이템정보"), SerializeField]
    public Equip_ShowInfo showInfo;

    Queue<GameObject> slotQueue;
    List<GameObject> slotList;
    Character SelectedCharacter;
    private void Start()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if(Instance!=this)
            {
                Destroy(this.gameObject);
            }
        }
        slotQueue = ObjectPooling.Instance.CreateQueue();
        slotList = new List<GameObject>();
    }
   void removeAll()
    {
        for(int i=0;i< slotList.Count;i++)
        {
            ObjectPooling.Instance.ReturnPoolObj(slotQueue, Equip_InventorySlotParent, slotList[i]);
        }
        slotList.Clear();
    }
    public void SelectCharacter(Character character)
    {
        SelectedCharacter = character;
    }
    public void ShowItem(string itemdetailtype)
    {
        removeAll();
        ItemDetailType _itemdetailtype = (ItemDetailType)Enum.Parse(typeof(ItemDetailType), itemdetailtype);
        List<Item> playeritems = Player.Instance.InventoryItemList;

        for (int i=0;i< playeritems.Count;i++)
        {
            if (playeritems[i].Item_DetailType== _itemdetailtype)
            {
                GameObject newslot = ObjectPooling.Instance.GetPoolObj(slotQueue, Equip_InventorySlotParent, Equip_InventorySlotPrefab.gameObject);
                newslot.GetComponent<Equip_InventorySlot>().getItem(playeritems[i]);
                slotList.Add(newslot);
            }
        }
    }

    public void ShowAllEquipItem(int num)
    {
        //리셋필요\
        for(int i=0;i< EquipSlots.Length;i++)
        {
            EquipSlots[i].removeItem();
        }

        SelectedCharacter = Player.Instance.MyCharacters[num];
        if (SelectedCharacter != null)
        {
            for(int i=0;i< SelectedCharacter.EquipItemList.Count;i++)
            {
                for (int j = 0; j < EquipSlots.Length; j++)
                {
                    if (EquipSlots[j].SlotType == SelectedCharacter.EquipItemList[i].Item_DetailType)
                    {
                        EquipSlots[j].getItem(SelectedCharacter.EquipItemList[i]);
                    }
                }
            }
        }
    }
    public void ClickEquipSlots(EquipSlot slot)
    {
        if(slot.SlotItem!=null)
        {
            showInfo.getItem(slot.SlotItem);
        }
    }
    public void ClickEquipSlots(Equip_InventorySlot slot)
    {
        if (slot.slotItem != null)
        {
            showInfo.getItem(slot.slotItem);
        }
    }
    public void ExitEquip()
    {
        for(int i=0;i< EquipSlots.Length;i++)
        {
            EquipSlots[i].removeItem();
        }
    }
    public void EquipItem(Equip_InventorySlot slot)
    {
        if(SelectedCharacter!=null)
        {
            SelectedCharacter.EquipItem(slot.slotItem);
            for(int i=0;i< EquipSlots.Length;i++)
            {
                if (EquipSlots[i].SlotType== slot.slotItem.Item_DetailType)
                {
                    EquipSlots[i].getItem(slot.slotItem);

                    slotList.Remove(slot.gameObject);
                    Inventory.Instance.RemoveItem(slot.slotItem);
                    ObjectPooling.Instance.ReturnPoolObj(slotQueue, Equip_InventorySlotParent, slot.gameObject);
                    break;
                }
            }

        }
        else
        {
            Debug.Log("선택된 케릭터가 없습니다!");
        }

    }





}
