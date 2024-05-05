using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestySuper1 : MonoBehaviour
{

    public GameObject superball;
    public GameObject shardsPrefab;

    public GameObject opponent;

    // Start is called before the first frame update
    void Start()
    {
        opponent = GameObject.FindGameObjectWithTag("Player 2");
        Vector2 pos = superball.transform.position;
        superball.transform.position = Vector3.MoveTowards(pos, new Vector2(0, 3), 5f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
