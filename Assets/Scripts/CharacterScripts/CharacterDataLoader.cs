using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// Character Specific Data
// Name, Animations, Movesets, 
// Scriptable Object

[CreateAssetMenu(fileName = "CharacterLoader", menuName = "CharacterLoader")]
public class CharacterDataLoader : ScriptableObject
{
    public string charName; // Name of Character
    public Sprite charImage; // Sprite of Character
    public AudioClip selectLine; // Voice Line when Character is Selected
    public int characterSpeed;
    public CharacterManager PlayerTag;
    public CharacterManager OpponentTag;
    //Light Attack
    public int lightAttackDamage;
    public float lightAttackPosY;
    public float lightAttackPosX;
    public float lightAttackFrameCount;
    public Vector2 lightAttackHitboxScale;

    //Heavy Attack
    public int heavyAttackDamage;
    public float heavyAttackPosY;
    public float heavyAttackPosX;
    public float heavyAttackFrameCount;
    public Vector2 heavyAttackHitboxScale;

    //Special Move stuff here

}
