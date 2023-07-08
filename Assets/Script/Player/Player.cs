using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField]
    public Character[] MyCharacters;
    [SerializeField]
    LobyManager lobymanager;

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






}
