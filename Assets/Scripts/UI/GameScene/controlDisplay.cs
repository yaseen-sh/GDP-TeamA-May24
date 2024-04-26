using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlDisplay : MonoBehaviour
{
    public GameObject controlHolder;
    // Start is called before the first frame update
    void Start()
    {
        controlHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) /*|| Input.GetButtonDown("Fire1")*/)
        {
            Debug.Log("Tab key is being held down");
            controlHolder.SetActive(true);
        }
        else
        {
            Debug.Log("false");
            controlHolder.SetActive(false);
        }
    }
}
