using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : CharacterBaseState
{
    CharacterMovement movement;
    Hitbox hitbox;
    CharacterAttack attack;
    public override void EnterState(CharacterStateMachine state)
    {
        //Lock Movement
        //movement.speed = 0;
        //Play animation
        Debug.Log("AttackingState");
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        //after windup and winddown 
        //transition back to idle
        if (hitbox.timer < 0)
            state.SwitchState(state.IdleState);
    }
    public override void OnCollisionEnter(CharacterStateMachine state)
    {

        throw new System.NotImplementedException();
    }

}
