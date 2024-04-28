using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Super : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    Hitbox hitbox;
    public override void EnterState(CharacterStateMachine state)
    {
        movement = state.character.GetComponent<CharacterMovement>();
        anime = state.character.GetComponent<Animations>();
        anime.Super();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
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