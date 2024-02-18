using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Setup for the Character Selection Screen. Takes a List of Character Tiles and Instantiates them into the character grid.
// To Display the Name and Sprite of the characters.

public class SetupCharTiles : MonoBehaviour
{
    [Header("List of CharTile Scriptable Objects")]
    [Space]
    public List<CharTile> fighters = new List<CharTile>();
    [Space]
    public GameObject charTilePrefab;

    void Start()
    {
        foreach (CharTile fighter in fighters)
        {
            Display(fighter);
        }
    }
    void Display(CharTile fighter)
    {
        GameObject tile = Instantiate(charTilePrefab, transform);
        tile.GetComponentInChildren<TextMeshProUGUI>().text = fighter.charName;
        tile.GetComponentInChildren<Image>().sprite = fighter.charImage;
    }
}
