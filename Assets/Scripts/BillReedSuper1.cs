using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BillReedSuper1 : MonoBehaviour
{
    //Player
    private GameObject playerOne;
    private CharacterMovement characterMovement;
    private Hitbox hitbox;

    // Start is called before the first frame update
    void Start()
    {
        //getting player two
        playerOne = GameObject.FindGameObjectWithTag("Player 1");
        characterMovement = playerOne.GetComponent<CharacterMovement>();
        hitbox = playerOne.GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.facingRight)
        {
            Debug.Break();
            //setting the beam to the other players transform
            transform.position = playerOne.transform.position + new Vector3(3.3f, -.7f);
        }
        else
        {
            Debug.Break();
            transform.position = playerOne.transform.position + new Vector3(-3.3f, -.7f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag != playerOne.tag)
        {
            Debug.Log("Nesteranko Super: I've hit something");
            hitbox.OnTriggerEnter2D(collision);
            Destroy(gameObject);
        }
    }
}
