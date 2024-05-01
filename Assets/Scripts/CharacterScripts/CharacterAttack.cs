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
    public string actionName = "Action";// action names
    
    private float frameCount; // counts duration of current attack
    private GameObject currentHitBox;
    //private SpriteRenderer hitBoxRenderer;
    
    protected Animator animator;
    protected bool shouldCombo;// if attack would combo into another
    protected int attackIndex;// the attack number in a combo string

    CharacterStateMachine characterState;
    public Hitbox hitbox;
    public CharacterManager controller;
    private SpriteRenderer hitBoxRenderer;
    private int attackID;
    //needed for stopping input

    //blocking
    public bool isBlocking = false;
    public GameObject hurtBox;
    private PlayerInput playerInput;
    private CharacterMovement characterMovement;
    private void Awake()
    {
        characterState = GetComponent<CharacterStateMachine>();
    }
    void Start()
    {
       playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterManager>();
        characterMovement = GetComponent<CharacterMovement>();

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

    public void AttackLight(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            //Debug.Log("AttackLightCalled");
            //frameCount = 0; // Reset frame count
            //if(keyPressed == false)
            hitbox.isAttacking = true;
            characterState.SwitchState(characterState.LightAttackingState);
            attackID = 1;
            StartCoroutine(StartUp(hitbox.StartUpFrames,attackID));
            
            //Debug.Log("light punch");
        }
    }
    public void AttackHeavy(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            hitbox.isAttacking = true;            
            characterState.SwitchState(characterState.HeavyAttackingState);
            attackID = 2;
            StartCoroutine(StartUp(hitbox.StartUpFrames, attackID));
        }
    }
    public void AttackSuper(InputAction.CallbackContext context)
    {
        if (hitbox.playerTag.CompareTag("Player 1") && !GameManager.super1Full) return;
        else if (hitbox.playerTag.CompareTag("Player 2") && !GameManager.super2Full) return;
        if (context.action.IsPressed())
        {
            hitbox.isAttacking = true;
            characterState.SwitchState(characterState.SuperState);
            attackID = 3;
            StartCoroutine(StartUp(hitbox.StartUpFrames, attackID));
        }
    }

    public void Block(InputAction.CallbackContext context)
    {
        if (context.performed) { 
            characterState.SwitchState(characterState.BlockingState);
            hurtBox.SetActive(false);
            attackID = 4;
            StartCoroutine(StartUp(0f, attackID));
            //characterState.StartCo((float)context.duration);
            //create timer to disable and re enable input
            isBlocking = true;
            characterMovement.isBlocking = true;
        }
        else //if(context.canceled)
        {
            Debug.Log("not blocking");

            characterState.SwitchState(characterState.IdleState);
           
            isBlocking = false;
            characterMovement.isBlocking = false;
            hurtBox.SetActive(true);
        }
    }

    IEnumerator StartUp(float frames, int ID )
    {
        yield return new WaitForSeconds(frames);

        Debug.Log("Start Up Frames: " + frames);
        hitbox.SpawnHitbox(ID);//attack type 1;
    }

}
