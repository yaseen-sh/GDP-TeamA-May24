using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
    Manages Characters + Stages
*/
public class CSSManager : MonoBehaviour
{
    [Header("Player 1 Variables")]
    public static bool player1Selected = false; 
    public static Sprite player1Fighter;
    public static string player1FighterName;
    public static GameObject player1Object;
    public static AudioClip player1Intro;

    [Header("Player 2 Variables")]
    public static bool player2Selected = false;
    public static Sprite player2Fighter;
    public static string player2FighterName;
    public static GameObject player2Object;
    public static AudioClip player2Intro;

    [Header("Selected Stage")]
    public static Sprite stage;
    public static string stageName;
    public static AudioClip stageTheme;

    public static bool gameOver = false;
}
