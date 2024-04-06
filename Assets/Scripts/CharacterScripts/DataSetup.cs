using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataSetup : MonoBehaviour
{
    [Header("List of CharTile Scriptable Objects")]
    [Space]
    public List<CharacterDataLoader> fighters = new List<CharacterDataLoader>();
    [Space]
    public GameObject charTilePrefab;
    [Space]
    [Header("Player 1's Side")]
    public GameObject player1Char;
    public TextMeshProUGUI player1Name;
    public CharacterAttack player1Moveset;
    //Attack values
    public int lightAttackDamage1;
    public float lightAttackPosY1;
    public float lightAttackPosX1;
    public float lightAttackFrameCount1;
    public Vector2 lightAttackHitboxScale1;

    public int heavyAttackDamage1;
    public float heavyAttackPosY1;
    public float heavyAttackPosX1;
    public float heavyAttackFrameCount1;
    public Vector2 heavyAttackHitboxScale1;

    [Header("Player 2's Side")]
    public GameObject player2Char;
    public TextMeshProUGUI player2Name;
    public CharacterAttack player2Moveset;

    [Header("default")]
    public Sprite defaultImage;

    [Header("Ready?")]
    public GameObject ready;

    // Intial Setup
    void Start()
    {
        ready.SetActive(false);
        player1Name.text = "";
        player2Name.text = "";
        player1Char.SetActive(false);
        player2Char.SetActive(false);
    }
}
