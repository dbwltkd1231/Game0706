using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
  
    [Header("All ди╦╞ем"), SerializeField]
    public Character[] AllCharacters;


    public Character FindCharacter(int ID)
    {
        Character newCharacter = new Character();
        for (int i=0;i< AllCharacters.Length;i++)
        {
            if (AllCharacters[i].ID==ID)
            {
                newCharacter = AllCharacters[i];
                break;
            }
        }
        return newCharacter;


    }



}
