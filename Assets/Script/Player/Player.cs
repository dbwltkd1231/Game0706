using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player Instance;
    [Header("케릭터데이터 저장경로"), SerializeField]
    string csv_FileName;
    [Header("케릭터 저장소"), SerializeField]
    CharacterManager _CharacterManager;
    [SerializeField]
    public Character[] MyCharacters;
    [SerializeField]
    LobyManager lobymanager;




    public List<Item> InventoryItemList;
    public List<PlayableCharacter> PlayabeCharacterList;
    private void Awake()
    {
        if (Instance == null)
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
   
    public void init()
    {
        InventoryItemList = new List<Item>();
        PlayabeCharacterList = new List<PlayableCharacter>();
        //임시세팅
        ReadCharacterData(100, 3, 0);
        ReadCharacterData(101, 7, 1);
    }
    public void LobySeletCharacter(LobyCharacter lobycharacter)
    {
        for(int i=0;i< MyCharacters.Length;i++)
        {
            if(lobycharacter.ID== MyCharacters[i].ID)
            {
                lobymanager.SelectCharacter(MyCharacters[i]);
                break;
            }
        }
    }
    public void ShowCharacterData()
    {
        for(int i=0;i<lobymanager.characterslots.Length;i++)
        {

        }
    }

    void ReadCharacterData(int ID,int level,int num)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(csv_FileName);
        MyCharacters[num] = _CharacterManager.FindCharacter(ID);
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["ID"].ToString() == "End")
            {
                break;
            }
            if (data[i]["ID"].ToString() == ID.ToString()&& data[i]["레벨"].ToString() == level.ToString())//.ToString()&& (int)data[i]["레벨"] == level
            {
                MyCharacters[num].Level = level;
                MyCharacters[num].ATT = int.Parse(data[i]["공격력"].ToString());
                MyCharacters[num].DEF = int.Parse(data[i]["방어력"].ToString());
                MyCharacters[num].MaxHp = int.Parse(data[i]["체력"].ToString());
                MyCharacters[num].Grade = int.Parse(data[i]["등급"].ToString());
                MyCharacters[num].Crt = int.Parse(data[i]["크리티컬확률"].ToString());
                MyCharacters[num].LobyImage = Resources.Load<Sprite>(data[i]["이미지"].ToString());
                MyCharacters[num].EquipItemList = new List<Item>();
            }
          

        }
    }

    void AdventureInit()
    {
        for(int i=0;i< MyCharacters.Length;i++)
        {
            GameObject playablecharacter = Instantiate(MyCharacters[i].PlayableCharacterPrefab.gameObject);
            PlayabeCharacterList.Add(playablecharacter.GetComponent<PlayableCharacter>());
        }
    }




}
