using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataSetup : MonoBehaviour
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
