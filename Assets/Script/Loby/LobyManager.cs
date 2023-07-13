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
    [Header("�ɸ��� ����_�ɸ���"), SerializeField]
    GameObject Characters;
    [Header("�ɸ��� ����_���"), SerializeField]
    GameObject Equip;
    [Header("����"), SerializeField]
    GameObject Shop;
    [Header("�κ��丮"), SerializeField]
    GameObject Inventory;
    [Header("�κ�_�ɸ��ͽ���"), SerializeField]
    Transform[] LobySlots;
    [Header("�ɸ��Ͱ���_�ɸ��ͽ���"), SerializeField]
    public CharacterSlot[] characterslots; 

    List<Character> LobyCharacters;

    private void Start()
    {
        Player.Instance.init();
        init();
    }

    public void init()
    {
        Main.SetActive(true);
        CharacterManager.SetActive(false);
        Shop.SetActive(false);
        Inventory.SetActive(false);

        ShowLobby();
        SelectCharacter(LobyCharacters[0]);

        for(int i=0;i< characterslots.Length;i++)
        {
            characterslots[i].SetCharacter(Player.Instance.MyCharacters[i]);
        }
    }


     void ShowLobby()
    {
        LobyCharacters = new List<Character>();
        LobyCharacters = Player.Instance.MyCharacters.ToList();
        for (int i = 0; i < (LobyCharacters.Count > 2 ? 2 : LobyCharacters.Count); i++)//�ִ� 2���� �ɸ��ͱ����� ����
        {
            GameObject tmp = Instantiate(LobyCharacters[i].CharacterPrefab.gameObject, this.transform);
            tmp.GetComponent<LobyCharacter>().ID = LobyCharacters[i].ID;
            tmp.transform.SetParent(LobySlots[i],false);
        }
    }
    public void OpenEquip()
    {
        Characters.SetActive(false);
        Equip.SetActive(true);
    }
    public void SelectCharacter(Character character)
    {
        Loby_SelectedCharacterImage.sprite = character.LobyImage;
    }
    public void OpenCharacter()
    {
        CharacterManager.SetActive(true);
        Characters.SetActive(true);
        Equip.SetActive(false);
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
