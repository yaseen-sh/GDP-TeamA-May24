using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BransonUltimateControllerPlayerTwo : MonoBehaviour
{
    //Player
    private GameObject playerOne;
    private GameObject playerTwo;
    public Hitbox hitbox2;


    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerOne = GameObject.FindGameObjectWithTag("Player 1");
        playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        hitbox2 = playerTwo.GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting the beam to the other players transform
        transform.position = playerOne.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag != playerOne.tag)
        {
            Debug.Log("Branson Super: I've hit something");
            hitbox2.OnTriggerEnter2D(collision);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
