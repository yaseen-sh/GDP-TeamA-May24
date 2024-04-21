using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttacking : CharacterBaseState
{
    CharacterMovement movement;
    Hitbox hitbox;
    CharacterAttack attack;
    Animations anime;
    public override void EnterState(CharacterStateMachine state)
    {
        hitbox = state.character.GetComponent<Hitbox>();
        anime = state.character.GetComponent<Animations>();
        anime.heavyAttack();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        if (hitbox.activeHitboxFrames <= 0)
            state.SwitchState(state.IdleState);
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}