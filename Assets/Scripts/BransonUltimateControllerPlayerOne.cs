using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BransonUltimateControllerPlayerOne : MonoBehaviour
{
    //Player
    private GameObject playerTwo;



    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerTwo = GameObject.FindGameObjectWithTag("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        //setting the beam to the other players transform
        transform.position = playerTwo.transform.position;
    }
}
