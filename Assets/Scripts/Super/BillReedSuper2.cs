using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BillReedSuper2 : MonoBehaviour
{
    //Player
    private GameObject playerTwo;
    private CharacterMovement characterMovement;
    private Hitbox hitbox;

    // Start is called before the first frame update
    void Start()
    {
        //getting player Two
        playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        characterMovement = playerTwo.GetComponent<CharacterMovement>();
        hitbox = playerTwo.GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.facingRight)
        {
            
            //setting the beam to the other players transform
            transform.position = playerTwo.transform.position + new Vector3(3.5f, .2f);
        }
        else
        {
            transform.position = playerTwo.transform.position + new Vector3(-3.5f, .2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag != playerTwo.tag)
        {
            Debug.Log("Nesteranko Super: I've hit something");
            hitbox.OnTriggerEnter2D(collision);
            Destroy(gameObject);
        }
    }
}
