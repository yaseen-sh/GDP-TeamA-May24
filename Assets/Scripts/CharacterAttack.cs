using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    CharacterAttack() { }
    // Update is called once per frame
    public CharacterController controller;

    void FixedUpdate()
    {
        // Sets the fixed delta time to 60fps.
        Time.fixedDeltaTime = 1 / 60;
        StartFrames();
    }
    float Attack()
    {
        return 0;
    }
    float StartFrames()
    {
        return 0;
    }
    float ActiveFrames()
    {
        return 0;
    }
    float RecoveryFrames()
    {
        return 0;
    }
    float HitStunFrames()
    {
        return 0;
    }
    float BlockStunFrames()
    {
        return 0;
    }
    string AttackProperty()
    {
        return "";
    }

}
