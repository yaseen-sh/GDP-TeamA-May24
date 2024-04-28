using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

/*
    Setup for the Character Selection Screen. Takes a List of Character Tiles and Instantiates them into the character grid.
    To Display the Name and Sprite of the characters. Also Used to determine whether a cursor is hovering over a character tile
    to display the coresponding name and sprite. Determines which cursor is hovering by making the tiles either red or blue to
    match the cursor.
*/
public class SetupCharTiles : MonoBehaviour
{
    [Header("List of CharTile Scriptable Objects")]
    [Space]
    public List<CharTile> fighters = new List<CharTile>();
    [Space]
    public GameObject charTilePrefab;
    [Space]
    [Header("Player 1's Side")]
    public GameObject player1Char;
    public TextMeshProUGUI player1Name;

    [Header("Player 2's Side")]
    public GameObject player2Char;
    public TextMeshProUGUI player2Name;

    [Header("default")]
    public Sprite defaultImage;

    [Header("Used for Detecting if the Cursor is over a Tile")]
    public List<GameObject> allTiles = new List<GameObject>();

    public Dictionary<string, string> charIdles = new Dictionary<string, string>(); // Dictionary of Names of Char Idles Animations
    public Dictionary<string, string> charPicks = new Dictionary<string, string>(); // Dictionary of Names of Char Ready Animations

    public static Dictionary<string, AudioClip> charA1Lines = new Dictionary<string, AudioClip>();
    public static Dictionary<string, AudioClip> charA2Lines = new Dictionary<string, AudioClip>();

    public Button backButton;

    [Header("Ready?")]
    public GameObject ready;

    // Intial Setup
    void Start()
    {
        ready.SetActive(false);
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
        for (int i = 0; i < fighter.selectLine.Length; ++i)
        {
            tile.GetComponents<AudioSource>()[i].clip = fighter.selectLine[i];
        }
        charIdles.Add(fighter.charName, fighter.charIdle);
        charPicks.Add(fighter.charName, fighter.charReadyAnim);

        if (!charA1Lines.ContainsKey(fighter.charName) && !charA2Lines.ContainsKey(fighter.charName))
        {
            charA1Lines.Add(fighter.charName, fighter.anouncerLine[0]);
            charA2Lines.Add(fighter.charName, fighter.anouncerLine[1]);
        }
        allTiles.Add(tile);
    }

    void Update()
    {
        bool is1Hovered = true;
        bool is2Hovered = true;
        // Player 1 Controller
        if (/*!GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected*/ !CSSManager.player1Selected && GameObject.FindGameObjectWithTag("CursorP1") != null)
        {
            is1Hovered = false;
            foreach (GameObject fighter in allTiles)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                {
                    var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, .5f, .5f);
                    fighter.GetComponentInChildren<Button>().colors = buttonColor;
                    player1Char.SetActive(true);
                    player1Name.text = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                    player1Char.GetComponent<Image>().sprite = fighter.GetComponentInChildren<Image>().sprite;

                    if(charIdles[player1Name.text] != null) player1Char.GetComponent<Animator>().Play(charIdles[player1Name.text]);
                    is1Hovered = true;
                    break;
                }
            }
        }
        if (/*GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected*/ CSSManager.player1Selected)
        {
            if (charIdles[player1Name.text] != null) player1Char.GetComponent<Animator>().Play(charPicks[player1Name.text]);
        }
        // Player 2 Controller
        if (/*!GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected*/ !CSSManager.player2Selected && GameObject.FindGameObjectWithTag("CursorP2") != null)
        {
            is2Hovered = false;
            foreach (GameObject fighter in allTiles)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                {
                    var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                    buttonColor.normalColor = new Color(.5f, 0, 0, .5f);
                    fighter.GetComponentInChildren<Button>().colors = buttonColor;
                    player2Char.SetActive(true);
                    player2Name.text = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                    player2Char.GetComponent<Image>().sprite = fighter.GetComponentInChildren<Image>().sprite;

                    if (charIdles[player2Name.text] != null) player2Char.GetComponent<Animator>().Play(charIdles[player2Name.text]);
                    is2Hovered = true;
                    break;
                }
            }
        }
        if (/*GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected*/ CSSManager.player2Selected)
        {
            if (charIdles[player2Name.text] != null) player2Char.GetComponent<Animator>().Play(charPicks[player2Name.text]);
        }
        // Case if player 1 and player 2 are not hovered (set all tiles back to Orignal Color)
        if (!is1Hovered && !is2Hovered)
        {
            foreach (GameObject fighter in allTiles)
            {
                var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                buttonColor.normalColor = new Color(0, 0, 0, 0);
                fighter.GetComponentInChildren<Button>().colors = buttonColor;
            }
            player1Name.text = "";
            player1Char.SetActive(false);
            player2Name.text = "";
            player2Char.SetActive(false);
        }
        else if (is1Hovered && !is2Hovered) // Case if player 1 is hovered but player 2 is not hovered
        {
            foreach (GameObject fighter in allTiles)
            {
                // All blue Tiles except the one player 1 is currently hovering are changed back to thier orignal color
                if (player1Name.text != fighter.GetComponentInChildren<TextMeshProUGUI>().text)
                {
                    var blue = new Color(0, 0, .5f, .5f);
                    if (fighter.GetComponentInChildren<Button>().colors.normalColor == blue)
                    {
                        var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                        buttonColor.normalColor = new Color(0, 0, 0, 0);
                        fighter.GetComponentInChildren<Button>().colors = buttonColor;
                    }
                }
                // all Tiles player 2 made red, back to their orignal color
                var red = new Color(.5f, 0, 0, .5f);
                if (fighter.GetComponentInChildren<Button>().colors.normalColor == red)
                {
                    var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    fighter.GetComponentInChildren<Button>().colors = buttonColor;
                }
            }
            player2Name.text = "";
            player2Char.SetActive(false);
        }
        else if (!is1Hovered && is2Hovered) // Case if player 2 is hovered but player 1 is not hovered
        {
            foreach (GameObject fighter in allTiles)
            {
                // All red Tiles except the one player 2 is currently hovering are changed back to thier orignal color
                if (player2Name.text != fighter.GetComponentInChildren<TextMeshProUGUI>().text)
                {
                    var red = new Color(.5f, 0, 0, .5f);
                    if (fighter.GetComponentInChildren<Button>().colors.normalColor == red)
                    {
                        var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                        buttonColor.normalColor = new Color(0, 0, 0, 0);
                        fighter.GetComponentInChildren<Button>().colors = buttonColor;
                    }
                }
                // all Tiles player 1 made blue, back to their orignal color
                var blue = new Color(0, 0, .5f, .5f);
                if (fighter.GetComponentInChildren<Button>().colors.normalColor == blue)
                {
                    var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    fighter.GetComponentInChildren<Button>().colors = buttonColor;
                }
            }
            player1Name.text = "";
            player1Char.SetActive(false);
        }
        else if (is1Hovered && is2Hovered) // Case if player 1 and player 2 are both hovered 
        {
            foreach (GameObject fighter in allTiles)
            {
                // All blue Tiles except the one player 1 is currently hovering are changed back to thier orignal color
                if (player1Name.text != fighter.GetComponentInChildren<TextMeshProUGUI>().text)
                {
                        var blue = new Color(0, 0, .5f, .5f);
                        if (fighter.GetComponentInChildren<Button>().colors.normalColor == blue)
                        {
                            var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                            buttonColor.normalColor = new Color(0, 0, 0, 0);
                            fighter.GetComponentInChildren<Button>().colors = buttonColor;
                        }
                }
                // All red Tiles except the one player 2 is currently hovering are changed back to thier orignal color
                if (player2Name.text != fighter.GetComponentInChildren<TextMeshProUGUI>().text)
                {
                        var red = new Color(.5f, 0, 0, .5f);
                        if (fighter.GetComponentInChildren<Button>().colors.normalColor == red)
                        {
                            var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                            buttonColor.normalColor = new Color(0, 0, 0, 0);
                            fighter.GetComponentInChildren<Button>().colors = buttonColor;
                        }
                }
                // If both cursors are hovering the same 1 then whoever selected it the color stays that color unless both are selected
                if (player1Name.text == player2Name.text)
                {
                    if (/*GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected*/ CSSManager.player1Selected)
                    {
                        var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                        buttonColor.normalColor = new Color(0, 0, .5f, .5f);
                        fighter.GetComponentInChildren<Button>().colors = buttonColor;
                    }
                    if (/*GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected*/ CSSManager.player2Selected)
                    {
                        var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                        buttonColor.normalColor = new Color(.5f, 0, 0, .5f);
                        fighter.GetComponentInChildren<Button>().colors = buttonColor;
                    }
                }
            }
        }
        /*
        foreach (GameObject fighter in allTiles)
        {
                // Mouse For Player 1
                if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), Input.mousePosition))
                {
                    player1Char.SetActive(true);
                    player1Name.text = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                    player1Char.GetComponent<Image>().sprite = fighter.GetComponentInChildren<Image>().sprite;
                    //is1Hovered = true;
                    break;
                }
        }*/
        if (/*GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected && 
            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected*/ CSSManager.player1Selected && CSSManager.player2Selected)
        {
            ready.transform.SetSiblingIndex(1000);
            ready.SetActive(true);
        }
        else
        {
            ready.SetActive(false);
        }
    }
}
