using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public CharacterDataLoader Data;
    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");

    }

    // Update is called once per frame
    void Update()
    {
        if (player1.transform.position.x < player2.transform.position.x)
        {
            player1.GetComponent<CharacterMovement>().facingRight = true;
            player2.GetComponent<CharacterMovement>().facingRight = false;
        }
        else
        {
            player1.GetComponent<CharacterMovement>().facingRight = false;
            player2.GetComponent<CharacterMovement>().facingRight = true;
        }
    }
}
