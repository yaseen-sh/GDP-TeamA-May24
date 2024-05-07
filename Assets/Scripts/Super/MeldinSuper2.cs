using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeldinSuper2 : MonoBehaviour
{
    private GameObject playerTwo;
    private Rigidbody2D rb;
    public Hitbox hitbox;
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        rb = GetComponent<Rigidbody2D>();
        hitbox = playerTwo.GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == 0 && transform.position.y == 0)
        {
            transform.position = new Vector2(playerTwo.transform.position.x + 10, 1);
        }
        rb.velocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag != playerTwo.tag)
        {
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
