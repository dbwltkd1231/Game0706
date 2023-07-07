using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<Item> InventoryItemList;
    public GameObject SlotPrefab;
    public InventorySlot SelectedSlot;


    [Header("�κ��丮 ����Ʈ"),SerializeField]
    Transform Content;
    [Header("��ȭ ��ư"), SerializeField]
    GameObject EnchantBttn;
    [Header("�Ǹ� ��ư"), SerializeField]
    GameObject SellBttn;
    Queue<GameObject> slotQueue;

    private void Awake()
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
    }
    public void SelectSlot(InventorySlot slot)
    {
        SelectedSlot = slot;
        ColorChange(slot.FrameImg);


        SellBttn.SetActive(true);
        if (SelectedSlot.ReturnItem().Item_Type==ItemType.���)
        {
            EnchantBttn.SetActive(true);
        }
    }
    public void GetItem(Item item)
    {
        InventoryItemList.Add(item);

        GameObject newslot =ObjectPooling.Instance.CreatePoolObj(slotQueue, Content, SlotPrefab);
        newslot.GetComponent<InventorySlot>().getItem(item);
        newslot.SetActive(true);
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
  
  
    public void ShowEquip()
    {
        for (int i = 0; i < InventoryItemList.Count; i++)
        {
            if (InventoryItemList[i].Item_Type==ItemType.���)
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

    void ColorChange(Image img)
    {
        Color color = new Color32(255, 0, 135, 255);
        img.color = color;
    }
}
