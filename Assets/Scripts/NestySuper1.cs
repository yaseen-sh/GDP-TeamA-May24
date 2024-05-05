using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestySuper1 : MonoBehaviour
{

    public GameObject superball;
    public GameObject shardsPrefab;
    public int numberOfShards = 5;
    public GameObject opponent;

    private CharacterManager OpponentTag;
    ParticleSystem particle;
    Vector2 pos;

    private void Awake()
    {
        hitbox = GetComponent<Hitbox>();
        OpponentTag = GameObject.FindGameObjectWithTag("Player 2").GetComponent<CharacterManager>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        particle = getComponent<ParticleSystem>();
        opponent = GameObject.FindGameObjectWithTag("Player 2");

        //want to find the object
        superball = GameObject.FindGameObjectWithTag("superBall");

        pos = superball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // until the ball reaches the desired position
        if(superball.transform.position != new Vector2(0, 3)){
            //move it to the middle at a certain speed
            superball.transform.position = Vector3.MoveTowards(pos, new Vector2(0, 3), 5f * Time.deltaTime);
        }
        //now we've reached the point
        else{
            //play explosive particle system
            //shoot out shards at slightly varying angles
            for(int i = 0; i < numberOfShards, ++i){
                StartCoroutine(wait(1)); //space out the timing of shards by a bit
                GameObject s = Instantiate(shardsPrefab, superball.transform.position);//instantiate prefab
                s.getChild(0).rotation += Random.range(-30f, 30f); //slightly randomize the location
                s.GetComponent<Rigidbody2D>().AddForce(s.transform.down * 10f); //launch it 
            }
            Destroy(gameObject);

            //will explode on collision
        }

        
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
    
    IEnumerator wait (float f)
    {
        yield return new WaitForSeconds (f);
        Destroy(super);
    }
}
