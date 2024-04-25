using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWalk : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    public override void EnterState(CharacterStateMachine state)
    {
        anime = state.character.GetComponent<Animations>();
        movement = state.character.GetComponent<CharacterMovement>();
        anime.BWalk();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        if (movement.moveValue == 0)
        {
            state.SwitchState(state.IdleState);
        }
    }
}
