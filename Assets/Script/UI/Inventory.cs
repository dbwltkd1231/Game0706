using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<Item> InventoryItemList;
    public GameObject SlotPrefab;
    public InventorySlot SelectedSlot;


    [Header("인벤토리 콘텐트"),SerializeField]
    Transform Content;
    [Header("강화 콘텐트"), SerializeField]
    Starpos StarposContent;
    [Header("강화 버튼"), SerializeField]
    GameObject EnchantBttn;
    [Header("판매 버튼"), SerializeField]
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
        UnityEngine.Color color = new Color32();
        if (SelectedSlot==null)
        {
            SelectedSlot = slot;
            color = new Color32(255, 0, 135, 255);
            slot.FrameImg.color = color;

            SellBttn.SetActive(true);
            if (SelectedSlot.ReturnItem().Item_Type == ItemType.장비)
            {
                EnchantBttn.SetActive(true);
            }
        }
        else if (slot == SelectedSlot)
        {
             color = new Color32(255, 255, 255, 255);
            SelectedSlot.FrameImg.color = color;
            SelectedSlot = null;
        }
        else
        {
            color = new Color32(255, 255, 255, 255);
            SelectedSlot.FrameImg.color = color;
            SelectedSlot = slot;
            color = new Color32(255, 0, 135, 255);
            slot.FrameImg.color = color;

            SellBttn.SetActive(true);
            if (SelectedSlot.ReturnItem().Item_Type == ItemType.장비)
            {
                EnchantBttn.SetActive(true);
            }
        }
        

        
    }
    public void OpenStarpos()
    {
        if(SelectedSlot!=null)
        {
            StarposContent.gameObject.SetActive(true);
            StarposContent.GetItem(SelectedSlot.ReturnItem());

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

    void ColorChange(Image img)
    {
       
    }
}
