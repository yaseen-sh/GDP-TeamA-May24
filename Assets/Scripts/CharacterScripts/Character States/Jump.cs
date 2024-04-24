using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    public override void EnterState(CharacterStateMachine state)
    {
        movement = state.character.GetComponent<CharacterMovement>();
        anime = state.character.GetComponent<Animations>();
        anime.Jump();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)// landing
    {
        
        if (movement.isJumping == false)
        {
            Debug.Log(movement.isJumping);
            state.SwitchState(state.IdleState);
        }
    }
}
