using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    // Update is called once per frame
    public Rigidbody2D rb;
    public LayerMask groundLayer; //ground layer so we know if we're above ground
    public bool isBlocking;
    Rigidbody2D cat;
    void Start()
    {
        Time.fixedDeltaTime = 1 / 60;
        //controllerAnimator = Character1.GetComponent<controllerAnimator>();
        isBlocking = false;
    }
    void FixedUpdate()
    {
        // Sets the fixed delta time to 60fps.

        StartFrames();
    }
    public void AttackPunch()
    {
        //controllerAnimator.setTrigger("Punching");
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
    float attack()
    {
        int damageDealt;
        return 0;
    }
    string AttackProperty()
    {
        return "";
    }

}
