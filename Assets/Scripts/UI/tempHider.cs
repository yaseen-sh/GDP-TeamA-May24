using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHider : MonoBehaviour
{
    public GameObject holder;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(holder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
