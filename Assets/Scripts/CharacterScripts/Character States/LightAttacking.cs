using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttacking : CharacterBaseState
{
    CharacterMovement movement;
    Hitbox hitbox;
    CharacterAttack attack;
    NesterankoAnimation anime = new NesterankoAnimation();
    Animator animate;

    public void awake()
    {
        animate = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Animator>();

    }
    public override void EnterState(CharacterStateMachine state)
    {
        //Lock Movement
       // movement.enabled = false;
        //Play animation
        //anime.lightAttack();
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
