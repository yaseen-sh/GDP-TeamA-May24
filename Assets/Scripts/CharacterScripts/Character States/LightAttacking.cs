using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttacking : CharacterBaseState
{
    public GameObject character;
    CharacterMovement movement;
    Hitbox hitbox;
    CharacterAttack attack;
    Animations anime;

    public void start()
    {

    }
  

    public override void EnterState(CharacterStateMachine state)
    {
        //Lock Movement
        //movement.enabled = false;
        //Play 
        anime = state.character.GetComponent<Animations>();
        anime.lightAttack();
        Debug.Log("LightAttackingState");
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        //after windup and winddown 
        //transition back to idle
        Debug.Log(hitbox.timer);
        if (hitbox.timer < 0)
            state.SwitchState(state.IdleState);
    }
    public override void OnCollisionEnter(CharacterStateMachine state)
    {

        throw new System.NotImplementedException();
    }

}
