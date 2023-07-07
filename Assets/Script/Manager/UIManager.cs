using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("메인"), SerializeField]
    GameObject Main;
    [Header("상점"), SerializeField]
    GameObject Shop;
    [Header("인벤토리"), SerializeField]
    GameObject Inventory;



    public void OpenShop()
    {
        Shop.SetActive(true);
        Main.SetActive(false);
    }
    public void OpenInventory()
    {
        Inventory.SetActive(true);
        Main.SetActive(false);
    }
    public void ReturnMain(GameObject currentObj)
    {
        currentObj.SetActive(false);
        Main.SetActive(true);
    }

}
