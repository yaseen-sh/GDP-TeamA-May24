using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BransonUltimateControllerPlayerOne : MonoBehaviour
{
    //Player
    private GameObject playerTwo;
    private GameObject playerOne;
    public Hitbox hitbox1;

    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        playerOne = GameObject.FindGameObjectWithTag("Player 1");
        hitbox1 = playerOne.GetComponent<Hitbox>();
        //hitbox = playerTwo.GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting the beam to the other players transform
        transform.position = playerTwo.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag != playerTwo.tag)
        {
            Debug.Log("Branson Super: I've hit something");
            hitbox1.OnTriggerEnter2D(collision);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
