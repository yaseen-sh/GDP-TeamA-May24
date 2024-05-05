using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBall_Nesty : MonoBehaviour
{

    public GameObject opponent;
    ParticleSystem particle;
    public GameObject superball;
    private Vector3 pos;
    Hitbox hitbox;
    public SuperMove superReference;


    // Start is called before the first frame update 
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        //opponent = GameObject.FindGameObjectWithTag("Player 2");
        //want to find the object
        superball = GameObject.FindGameObjectWithTag("superBall");
        hitbox = GetComponent<Hitbox>();
        pos = superball.transform.position;
        superReference = GetComponent<SuperMove>(); 
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("ontrigger");
        if (coll.gameObject.CompareTag("HurtBox") && hitbox.isAttacking == true)
        {
            //explode and destroy here
            //getComponentInChildren<SpriteRenderer>().sprite = "Assets/Sprites/NesterenkoSprites/nesty_super_5";
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
