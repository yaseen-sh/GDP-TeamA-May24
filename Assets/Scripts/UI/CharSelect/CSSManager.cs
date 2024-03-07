using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
    Manages Characters
*/
public class CSSManager : MonoBehaviour
{
    [Header("Player 1 Variables")]
    public bool player1Selected = false; 
    public Sprite player1Fighter;

    [Header("Player 2 Variables")]
    public bool player2Selected = false;
    public Sprite player2Fighter;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
