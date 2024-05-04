using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillReedSuper2 : MonoBehaviour
{
    //Player
    private GameObject playerTwo;
    private CharacterMovement characterMovement;


    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        characterMovement = playerTwo.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.facingRight)
        {
            //setting the beam to the other players transform
            transform.position = playerTwo.transform.position + new Vector3(1,1);
        }
        else
        {
            transform.position = playerTwo.transform.position + new Vector3(-1, 1);
        }

    }
}
