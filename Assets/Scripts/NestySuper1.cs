using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestySuper1 : MonoBehaviour
{

    //public GameObject superball;
    public GameObject shardsPrefab;
    public int numberOfShards = 7;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        //want to find the object
        //superball = GameObject.FindGameObjectWithTag("superBall");
        //superball = gameObject;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // until the ball reaches the desired position
        if (transform.position.x != 0 || transform.position.y != 3)
        {
            //move it to the middle at a certain speed
            transform.position = Vector3.MoveTowards(pos, new Vector2(0, 3), 5f * Time.deltaTime);
        }

        //now we've reached the point
        else
        {
            //play explosive particle system
            //shoot out shards at slightly varying angles
            for (int i = 0; i < numberOfShards; ++i)
            {
                StartCoroutine(wait(1)); //space out the timing of shards by a bit
                GameObject s = Instantiate(shardsPrefab, transform);//instantiate prefab
                s.transform.GetChild(0).Rotate(0, 0, Random.Range(-30f, 30f)); //slightly randomize the location
                //s.GetComponent<Rigidbody2D>().AddForce(s.transform.up * -10f); //launch it 
            }
            Destroy(gameObject);

            //will explode on collision
        }

    }

    IEnumerator wait(float f)
    {
        yield return new WaitForSeconds(f);
        //Destroy(super);
    }
}
