using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterStates : MonoBehaviour
{
    [SerializeField] List<KeyCode> Keys = new List<KeyCode>();
    [SerializeField] Text controlsTestText; // used for printing out buttons pressed
    
    MovesManager movesManager;
    void Awake()
    {
    if (movesManager == null)
        movesManager = FindObjectOfType<MovesManager>();
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
        DetectPressedKey();// reads key pressed
        PrintControls();
    }

    public void PrintControls()
    {
       Console.Write(controlsTestText.text);
    }

    public void DetectPressedKey()
    {
        //Go through all the Keys
        //To make it faster we can attach a class and put all the keys that are allowed to be pressed
        //This will make the process a bit faster rather than moving through all keys
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                Keys.Add(kcode); //Add the Key to the List

                if (!movesManager.CanMove(Keys)) //if there is no avilable Moves reset the list
                    StopAllCoroutines();

                StartCoroutine(ComboResetTime()); //Start the Reseting process
            }
        }
    }
    IEnumerator ComboResetTime()// amount of time to reset combo
    {
        yield return new WaitForSeconds(ComboResetTime);

        movesManager.PlayMove(Keys); //Run the move from the list
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
}
