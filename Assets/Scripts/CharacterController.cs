using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterAttack attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Sets the fixed delta time to 60fps.
        Time.fixedDeltaTime = 1 / 60;
        PlayerHealth();
        SuperMeter();

    }
    float PlayerHealth() // playerHealth
    {
        const float maxHealth = 1000;//should be reset to 1000 after end of round
        float currentHealth = maxHealth;
        return currentHealth;
    }
    float SuperMeter() // meter used for special moves
    {
        const float minMeter = 0;//after each match the minMeter should be reset to 0
        float currentMeter = minMeter;
        return currentMeter;
    }
    float MovementSpeed()// variable movement speed
    {
        return 0;
    }
    float BlockMeter()// a regenerative "shield" that degrades after each hit sustained
    {
        const float minMeter = 100;//after each match the minMeter should be reset to 100
        float currentMeter = minMeter;
        return currentMeter;
    }
    bool FacingRight()//if character is facing right, normal controls, else invert left right
    {
        return true; 
    }
    string status()// reports the current state of character. Used for testing/labbing mainly
    {
        string currentStatus = "Idle";
        return currentStatus;
    }
}
