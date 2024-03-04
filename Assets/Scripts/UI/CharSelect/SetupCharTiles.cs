using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.UI;
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
    [Space]
    public GameObject player1Char;
    public TextMeshProUGUI player1Name;
    public GameObject player2Char;
    public TextMeshProUGUI player2Name;
    public Sprite defaultImage;

    [Header("Used for Detecting if the Cursor is over a Tile")]
    public List<GameObject> allTiles = new List<GameObject>();

    void Start()
    {
        player1Name.text = "";
        player2Name.text = "";
        player1Char.GetComponent<Image>().sprite = defaultImage;
        player1Char.SetActive(false);
        player2Char.GetComponent<Image>().sprite = defaultImage;
        player2Char.SetActive(false);
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
        tile.GetComponentInChildren<Button>().onClick = fighter.select;
        allTiles.Add(tile);
    }

    void Update()
    {
        bool is1Hovered = false;
        bool is2Hovered = false;
        if (!GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected)
        {
            foreach (GameObject fighter in allTiles)
            {
                // Player 1 Controller
                if (GameObject.FindGameObjectWithTag("CursorP1") != null)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                    {
                        player1Char.SetActive(true);
                        player1Name.text = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                        player1Char.GetComponent<Image>().sprite = fighter.GetComponentInChildren<Image>().sprite;
                        is1Hovered = true;
                        break;
                    }
                }
            }
            if (!is1Hovered)
            {
                player1Name.text = "";
                player1Char.SetActive(false);
            }
        }
        if (!GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected)
        {
            foreach (GameObject fighter in allTiles)
            {
                // Player 2 Controller
                if (GameObject.FindGameObjectWithTag("CursorP2") != null)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                    {
                        player2Char.SetActive(true);
                        player2Name.text = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                        player2Char.GetComponent<Image>().sprite = fighter.GetComponentInChildren<Image>().sprite;
                        is2Hovered = true;
                        break;
                    }
                }
            }
            if (!is2Hovered)
            {
                player2Name.text = "";
                player2Char.SetActive(false);
            }
        }
        foreach (GameObject fighter in allTiles)
        {
                // Mouse For Player 1
                if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), Input.mousePosition))
                {
                    player1Char.SetActive(true);
                    player1Name.text = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                    player1Char.GetComponent<Image>().sprite = fighter.GetComponentInChildren<Image>().sprite;
                    is1Hovered = true;
                    break;
                }
        }
    }
}
