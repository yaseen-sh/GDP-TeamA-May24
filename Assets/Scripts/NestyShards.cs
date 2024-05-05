using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestyShards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider2D other)
    {
        //damage logic?

        //destroy
        Destroy(gameObject);
    }
}
