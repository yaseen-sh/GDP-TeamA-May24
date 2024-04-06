using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


//Context
public class CharacterStateMachine : MonoBehaviour
{
    protected CharacterController player;
    protected CharacterStateMachine stateMachine;
    protected Animator animationController;
    protected string animationName;
    public CharacterDataLoader Data;

    protected bool isExitingState;
    protected bool isAnimationFinished;
    protected float startTime;
    public IState CurrentState { get; private set; }
    
    public Idle IdleState = new Idle();
    public FWalk FWalkState = new FWalk();
    public BWalk BWalkState = new BWalk();
    public Jump JumpState = new Jump();
    public MidAir MidAirState = new MidAir();
    public Attacking AttackingState = new Attacking();
    public Blocking BlockingState = new Blocking();
    public Damaged DamagedState = new Damaged();
    public Wakeup WakeupState = new Wakeup();
    public Dead DeadState = new Dead();

    private void Start()
    {
        ChangeState(IdleState);
    }
    public CharacterStateMachine(CharacterController _player, CharacterStateMachine _stateMachine, Animator _animationController, string _animationName)
    {
        player = _player;
        stateMachine = _stateMachine;
        animationController = _animationController;
        animationName = _animationName;
    }
    public void ChangeState(IState newState)
    {
        CurrentState = newState;
    }
    
}

public interface IState
    {
        public void OnUpdate();
        void OnDisable();
        void OnEnable();
        void OnIdle();
        void OnWalk();
        void OnJump();
        void OnMidAir();
        void OnAttacking();
        void OnBlocking();
        void OnHitStunned();
        void OnDamaged();
        void OnWakeUp();
        void OnKnockDown();
        void OnDead();
}
