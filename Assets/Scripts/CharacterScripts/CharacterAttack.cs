using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/* 
 *  all your attacks neatly organized in an object and use several combinations of Hitboxes for any of them.
 *  To do that you would need a script that strictly delegates 
 *  OnTriggerEnter calls to your active attack or something along those lines.
*/
public class CharacterAttack : MonoBehaviour
{
    // Update is called once per frame
    public Rigidbody2D character;
    public LayerMask groundLayer; //ground layer so we know if we're above ground
    public bool isBlocking;
    public string actionName = "Action";// action names
    public int damage = 100;// amount of damage a attack does. for now 100
    
    private int frameCount = 0; // counts duration of current attack
    private GameObject currentHitBox;
    //private SpriteRenderer hitBoxRenderer;
    
    protected Animator animator;
    protected bool shouldCombo;// if attack would combo into another
    protected int attackIndex;// the attack number in a combo string

    public Hitbox hitbox;
    public CharacterController controller;
    
    private void Awake()
    {
        // Sets the fixed delta time to 60fps.
        Time.fixedDeltaTime = 1 / 60;
    }
    void Start()
    {
        isBlocking = false;
        InitializeHitBox();
    }
    void InitializeHitBox()
    {
        
        //hitBoxRenderer
        //Find hitbox renderer
        /*
        hitBoxRenderer = GetComponent<SpriteRenderer>();
        if (hitBoxRenderer == null)
            Debug.LogError("Hitbox renderer not found!");

        // Find current hitbox
        currentHitBox = hitBoxRenderer.gameObject;
        if (currentHitBox == null)
            Debug.LogError("Current hitbox not found!");
        */
       
    }
    void FixedUpdate()
    {
        if (currentHitBox != null)
        {
            //framecount -= time.deltatime;
            //if(frame <= 0; framecount = 0)
            //if (attackHappened then start frame counter
            //setup for each
            //time.deltatime

            frameCount++;
            if (frameCount > hitbox.hitboxDuration) // After hitbox duration, destroy hitbox and reset frame count
            {

                hitbox.DestroyHitbox(currentHitBox);
                frameCount = 0;
            }
        }
    }

    private void checkHit()
    {
        
        controller.currentHealth -= damage;
        controller.setPlayerHealth();
        //Debug.Log("Hit Confirmed");
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("HurtBox"))
        {
            checkHit();
            Debug.Log(coll.gameObject.name);
        }
    }
    public void AttackLight(InputAction.CallbackContext context)
    {
       // Debug.Log("AttackLightCalled");
        
        if (context.performed && currentHitBox == null)
        {
            frameCount = 0; // Reset frame count
            hitbox.SpawnHitbox();
           // Debug.Log("light punch");
        }
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
        return 0;
    }
    string AttackProperty()
    {
        return "";
    }
}
