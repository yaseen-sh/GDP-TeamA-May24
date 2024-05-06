using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestySuper1 : MonoBehaviour
{

    private GameObject playerOne;
    private Rigidbody2D rb;
    public Hitbox hitbox;
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player 1");
        rb = GetComponent<Rigidbody2D>();
        hitbox = playerOne.GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == 0 && transform.position.y == 0)
        {
            transform.position = new Vector2(playerOne.transform.position.x + 10, 1);
        }
        rb.velocity = Vector2.right * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent.tag != playerOne.tag)
        {
            Debug.Log("Nesteranko Super: I've hit something");
            hitbox.OnTriggerEnter2D(collision);
            Destroy(gameObject);
        }
    }

    IEnumerator wait(float f)
    {
        yield return new WaitForSeconds(f);
        //Destroy(super);
    }
}
