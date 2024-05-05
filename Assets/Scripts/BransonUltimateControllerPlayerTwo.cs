using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BransonUltimateControllerPlayerTwo : MonoBehaviour
{
    //Player
    private GameObject playerOne;



    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerOne = GameObject.FindGameObjectWithTag("Player 1");
    }

    // Update is called once per frame
    void Update()
    {
        //setting the beam to the other players transform
        transform.position = playerOne.transform.position;
    }
}
