using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Character Tile", menuName = "Character Tile")]
public class CharTile : ScriptableObject
{
    public string charName;
    public Sprite charImage;
}
