using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class LobyManager : MonoBehaviour
{
    [Header("�κ�_���õ� �ɸ��� �̹���"),SerializeField]
    Image Loby_SelectedCharacterImage;
    [Header("����"), SerializeField]
    GameObject Main;
    [Header("�ɸ��� ����"), SerializeField]
    GameObject CharacterManager;
    [Header("����"), SerializeField]
    GameObject Shop;
    [Header("�κ��丮"), SerializeField]
    GameObject Inventory;


    List<Character> LobyCharacters;
  
    private void Start()
    {
        ShowLobby();
        SelectCharacter(LobyCharacters[0]);
    }


    public void ShowLobby()
    {
        LobyCharacters = new List<Character>();
        LobyCharacters = Player.Instance.MyCharacters.ToList();
        for (int i = 0; i < (LobyCharacters.Count > 2 ? 2 : LobyCharacters.Count); i++)//�ִ� 2���� �ɸ��ͱ����� ����
        {
            GameObject tmp = Instantiate(LobyCharacters[i].CharacterPrefab.gameObject, this.transform);
            tmp.GetComponent<LobyCharacter>().ID = LobyCharacters[i].ID;
            tmp.transform.position = new Vector3(i *1.6f, 0.58f, -6.3f);
            tmp.transform.rotation = Quaternion.Euler(new Vector3(0, 213f, 0));
        }
    }
    public void SelectCharacter(Character character)
    {
        Loby_SelectedCharacterImage.sprite = character.LobyImage;
    }
    public void OpenCharacter()
    {
        CharacterManager.SetActive(true);
        Main.SetActive(false);
    }
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
