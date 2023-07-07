using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("����"), SerializeField]
    GameObject Main;
    [Header("����"), SerializeField]
    GameObject Shop;
    [Header("�κ��丮"), SerializeField]
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
