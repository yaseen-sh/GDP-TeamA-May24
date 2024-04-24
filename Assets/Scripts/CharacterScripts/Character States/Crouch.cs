using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    public override void EnterState(CharacterStateMachine state)
    {
        movement = state.character.GetComponent<CharacterMovement>();
        anime = state.character.GetComponent<Animations>();
        anime.Crouch();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        if (!movement.isCrouching)
            state.SwitchState(state.IdleState);
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}