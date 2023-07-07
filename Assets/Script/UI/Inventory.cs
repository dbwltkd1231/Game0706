using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> InventoryItemList;
    public GameObject SlotPrefab;
    [Header("인벤토리 콘텐트"),SerializeField]
    Transform Content;

    Queue<GameObject> slotQueue;

    public void GetItem(Item item)
    {
        InventoryItemList.Add(item);
    }
    public void RemoveItem(Item item)
    {
        InventoryItemList.Remove(item);
    }
    private void Reset()
    {
        for(int i=0;i< slotQueue.Count;i++)
        {
            ObjectPooling.Instance.ReturnPoolObj(slotQueue, Content, slotQueue.Peek());
        }
    }
    public void ShowAll()
    {
        for (int i = 0; i < InventoryItemList.Count; i++)
        {
            GameObject newslot =
            ObjectPooling.Instance.GetPoolObj(slotQueue, Content, SlotPrefab);
            newslot.GetComponent<InventorySlot>().getItem(InventoryItemList[i]);
        }
    }
    public void ShowEquip()
    {
        for (int i = 0; i < InventoryItemList.Count; i++)
        {
            if (InventoryItemList[i].Item_Type==ItemType.장비)
            {
                GameObject newslot =ObjectPooling.Instance.GetPoolObj(slotQueue, Content, SlotPrefab);
                newslot.GetComponent<InventorySlot>().getItem(InventoryItemList[i]);
            }
        }
    }

    private void Start()
    {
        slotQueue = ObjectPooling.Instance.CreateQueue();
        InventoryItemList = new List<Item>();
        
    }
}
