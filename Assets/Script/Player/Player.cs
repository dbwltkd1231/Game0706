using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player Instance;
    [Header("�ɸ��͵����� ������"), SerializeField]
    string csv_FileName;
    [Header("�ɸ��� �����"), SerializeField]
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
        //�ӽü���
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
            if (data[i]["ID"].ToString() == ID.ToString()&& data[i]["����"].ToString() == level.ToString())//.ToString()&& (int)data[i]["����"] == level
            {
                MyCharacters[num].Level = level;
                MyCharacters[num].ATT = int.Parse(data[i]["���ݷ�"].ToString());
                MyCharacters[num].DEF = int.Parse(data[i]["����"].ToString());
                MyCharacters[num].MaxHp = int.Parse(data[i]["ü��"].ToString());
                MyCharacters[num].Grade = int.Parse(data[i]["���"].ToString());
                MyCharacters[num].Crt = int.Parse(data[i]["ũ��Ƽ��Ȯ��"].ToString());
                MyCharacters[num].LobyImage = Resources.Load<Sprite>(data[i]["�̹���"].ToString());
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
