using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillReedSuper1 : MonoBehaviour
{
    //Player
    private GameObject playerOne;
    private CharacterMovement characterMovement;


    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerOne = GameObject.FindGameObjectWithTag("Player 1");
        characterMovement = playerOne.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.facingRight)
        {
            //setting the beam to the other players transform
            transform.position = playerOne.transform.position + new Vector3(1, 1);
        }
        else
        {
            transform.position = playerOne.transform.position + new Vector3(-1, 1);
        }
    }
}
