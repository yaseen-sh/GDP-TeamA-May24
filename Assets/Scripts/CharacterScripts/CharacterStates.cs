using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterStates : MonoBehaviour
{
    [SerializeField] List<KeyCode> Keys = new List<KeyCode>();
    [SerializeField] Text controlsTestText; // used for printing out buttons pressed
    
    //MovesManager movesManager;
    void Awake()
    {
        /*
    if (movesManager == null)
        movesManager = FindObjectOfType<MovesManager>();
        */
    }
    CharacterStates() { }
    // Update is called once per frame
    public CharacterController controller;
    void Start()
    {
        // Sets the fixed delta time to 60fps.
        Time.fixedDeltaTime = 1 / 60;
    }
    void FixedUpdate()
    {
        PrintControls();
    }

    public void PrintControls()
    {
      // Console.Write(controlsTestText.text);
    }

    
    IEnumerator ComboResetTime()// amount of time to reset combo
    {
        yield return new WaitForSeconds(1);

        //movesManager.PlayMove(Keys); //Run the move from the list
        Keys.Clear(); //Empty the list
    }

    //STATES
    void idle()
    {

    }
    void crouch()
    {

    }
    void midAir()
    {

    }
    void attacking()
    {

    }
    void blocking()
    {

    }
    void hitStunned()
    {

    }
    void blockStunned()
    {

    }
    void wakeUp()
    {

    }
    void knockDowned()
    {

    }
    void moving()
    {

    }
    public void dead()
    {
        Debug.Log("Character Is Dead");
    }
}
