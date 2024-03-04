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
   // public Rigidbody2D character;
    public LayerMask groundLayer; //ground layer so we know if we're above ground
    public bool isBlocking = false;
    public string actionName = "Action";// action names
    public int damage = 100;// amount of damage a attack does. for now 100
    
    private float frameCount = 10f; // counts duration of current attack
    private GameObject currentHitBox;
    //private SpriteRenderer hitBoxRenderer;
    
    protected Animator animator;
    protected bool shouldCombo;// if attack would combo into another
    protected int attackIndex;// the attack number in a combo string

    public Hitbox hitbox;
    public CharacterManager controller;
    private SpriteRenderer hitBoxRenderer;
    bool keyPressed;
    bool test;

    private void Awake()
    {
        
    }
    void Start()
    {
        controller = GetComponent<CharacterManager>();

        hitBoxRenderer = GetComponent<SpriteRenderer>();
        if (hitBoxRenderer == null)
            Debug.LogError("Hitbox renderer not found!");

        // Find current hitbox
        currentHitBox = hitBoxRenderer.gameObject;
        if (currentHitBox == null)
            Debug.LogError("Current hitbox not found!");
        hitbox = GetComponent<Hitbox>();
        // controller.SetPlayerHealth();
        //controller.SetSuperMeter();
    }
    
    private void Update()
    {
        if (test)
        {
            Debug.Log("AttackLightHappened");
            test = false;
        }

    }
    void FixedUpdate()
    {
        
    }

    public void AttackLight(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            Debug.Log("AttackLightCalled");
            //frameCount = 0; // Reset frame count
            //if(keyPressed == false)
            hitbox.SpawnHitbox(1);//attack type 1;
                                  //Debug.Log("light punch");

            test = true;
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
