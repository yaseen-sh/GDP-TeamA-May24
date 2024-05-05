using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBall_Nesty : MonoBehaviour
{

    public GameObject opponent;


    // Start is called before the first frame update 
    void Start()
    {
        particle = getComponent<ParticleSystem>();
        //opponent = GameObject.FindGameObjectWithTag("Player 2");
        //want to find the object
        superball = GameObject.FindGameObjectWithTag("superBall");

        pos = superball.transform.position;
    }

    void OnTriggerEnter2D(collider other){
        //Debug.Log("ontrigger");
        if (coll.gameObject.CompareTag("HurtBox") && hitbox.isAttacking == true)
        {
            //Debug.Log(coll.gameObject.name);
            OpponentTag.GetPlayerHealth();
            OpponentTag.SetPlayerHealth(2,1);
            //Debug.Log("Hit Confirmed");
        }
        else if (coll.gameObject.CompareTag("BlockBox"))
        {
            OpponentTag.GetPlayerHealth();
            OpponentTag.SetPlayerHealth(1, 1);
        }

        //explode and destroy here
        //getComponentInChildren<SpriteRenderer>().sprite = "Assets/Sprites/NesterenkoSprites/nesty_super_5";
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
