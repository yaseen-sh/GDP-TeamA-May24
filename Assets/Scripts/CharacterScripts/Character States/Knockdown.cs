using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockdown : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    Hitbox hitbox;
    public override void EnterState(CharacterStateMachine state)
    {
        hitbox = state.character.GetComponent<Hitbox>();
        movement = state.character.GetComponent<CharacterMovement>();
        anime = state.character.GetComponent<Animations>();
        anime.Knockdown();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        if (state.stateTimer >= hitbox.totalFrameCount)
        {
            state.stateTimer = 0;
            state.SwitchState(state.IdleState);
        }
    }
}
