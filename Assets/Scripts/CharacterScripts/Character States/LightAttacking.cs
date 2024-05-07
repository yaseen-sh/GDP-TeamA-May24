using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightAttacking : CharacterBaseState
{
    public GameObject character;
    CharacterMovement movement;
    Hitbox hitbox;
    CharacterAttack attack;
    Animations anime;
    IEnumerator coroutine;
    PlayerInput playerInput;
    public override void EnterState(CharacterStateMachine state)
    {
        //Lock Movement
        //movement.enabled = false;
        //Play 
        hitbox = state.character.GetComponent<Hitbox>();
        anime = state.character.GetComponent<Animations>();
        attack = state.character.GetComponent <CharacterAttack>();
        playerInput = state.character.GetComponent<PlayerInput>();  
        state.StartCo(hitbox.totalFrameCount);
        anime.lightAttack();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        //after windup and winddown 
        //transition back to idle
        if (state.stateTimer >= hitbox.totalFrameCount)
        {
            state.stateTimer = 0;
            state.SwitchState(state.IdleState);
        }
    }
    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

}
