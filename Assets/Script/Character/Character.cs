using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Character_",menuName ="Character")]
public class Character : ScriptableObject
{
    public LobyCharacter CharacterPrefab;
    public Sprite LobyImage;
    public int ID;

    public string Name;
    public int Level;
    public int ATT;
    public int DEF;
    public int MaxHp;
    public int Crt;
    // public int CurrentHp;
    public int Grade;
    



}
