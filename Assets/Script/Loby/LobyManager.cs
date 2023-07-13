using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class LobyManager : MonoBehaviour
{
    [Header("로비_선택된 케릭터 이미지"),SerializeField]
    Image Loby_SelectedCharacterImage;
    [Header("메인"), SerializeField]
    GameObject Main;
    [Header("케릭터 관리"), SerializeField]
    GameObject CharacterManager;
    [Header("케릭터 관리_케릭터"), SerializeField]
    GameObject Characters;
    [Header("케릭터 관리_장비"), SerializeField]
    GameObject Equip;
    [Header("상점"), SerializeField]
    GameObject Shop;
    [Header("인벤토리"), SerializeField]
    GameObject Inventory;
    [Header("로비_케릭터슬롯"), SerializeField]
    Transform[] LobySlots;
    [Header("케릭터관리_케릭터슬롯"), SerializeField]
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
        for (int i = 0; i < (LobyCharacters.Count > 2 ? 2 : LobyCharacters.Count); i++)//최대 2명의 케릭터까지만 등장
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
