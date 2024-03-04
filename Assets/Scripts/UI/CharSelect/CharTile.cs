using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character Tile", menuName = "Character Tile")]
public class CharTile : ScriptableObject
{
    public string charName; // Name of Character
    public Sprite charImage; // Sprite of Character
    public Button.ButtonClickedEvent select; // Button Action
}
