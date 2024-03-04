using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


// Manages Characters
public class CharManager : MonoBehaviour
{
    [Header("Player 1 Variables")]
    public bool player1Selected = false; 
    public Sprite player1Fighter;

    [Header("Player 2 Variables")]
    public bool player2Selected = false;
    public Sprite player2Fighter;

    [Header("Ready?")]
    public GameObject ready;

    public void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene().name == "CharacterSelectPvP")
            ready.SetActive(false);
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "CharacterSelectPvP")
        {
            if (player1Selected && player2Selected)
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
}
