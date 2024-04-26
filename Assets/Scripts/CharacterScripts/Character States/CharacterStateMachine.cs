using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UI;


//Context
public class CharacterStateMachine : MonoBehaviour
{
    public CharacterDataLoader Data;
    protected CharacterController player;

    public GameObject character;
    protected bool isExitingState;
    protected bool isAnimationFinished;
    protected float startTime;

    private PlayerInput playerInput;
    public CharacterBaseState CurrentState;
    public Idle IdleState = new Idle();
    public Crouch CrouchState = new Crouch();
    public FWalk FWalkState = new FWalk();
    public BWalk BWalkState = new BWalk();
    public Jump JumpState = new Jump();
    public LightAttacking LightAttackingState = new LightAttacking();
    public HeavyAttacking HeavyAttackingState = new HeavyAttacking();
    public Blocking BlockingState = new Blocking();
    public Damaged DamagedState = new Damaged();
    public Wakeup WakeupState = new Wakeup();
    public Dead DeadState = new Dead();

    public float stateTimer = 0f;
    public Animations anime;
    private void Start()
    {
        character = gameObject;
        //On start character starts in Idle
        CurrentState = IdleState;
        CurrentState.EnterState(this);
        playerInput = gameObject.GetComponent<PlayerInput>();
        anime = gameObject.GetComponent<Animations>();
    }
    public void SwitchState(CharacterBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
        Debug.Log("Current State is: " + CurrentState);
    }
    public void Update()
    {
        stateTimer += Time.deltaTime;
        //Debug.Log(stateTimer);
        CurrentState.UpdateState(this);
    }
    public IEnumerator DisableInputForDuration(float duration)
    {
        playerInput.enabled = false; //pausing input
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);
        playerInput.enabled = true; //resuming input
    }
    public void StartCo(float duration)
    {
        StartCoroutine(DisableInputForDuration(duration));
    }


}

