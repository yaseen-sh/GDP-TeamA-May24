using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : CharacterBaseState
{
    CharacterMovement movement;
    Hitbox hitbox;

    Animations anime;
    public override void EnterState(CharacterStateMachine state)
    {

        movement = state.character.GetComponent<CharacterMovement>();

        hitbox = state.character.GetComponent<Hitbox>();

        anime = state.character.GetComponent<Animations>();

        state.StartCo(hitbox.hitStun);

        anime.Damaged();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {


        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        //after windup and winddown 

        //transition back to idle

        if (state.stateTimer >= hitbox.hitStun)
        {
            state.stateTimer = 0;
            state.SwitchState(state.IdleState);
        }
    }
}

