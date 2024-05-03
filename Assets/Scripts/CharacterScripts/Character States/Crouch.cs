using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    CharacterAttack attack;
    Hitbox hitbox;
    public override void EnterState(CharacterStateMachine state)
    {
        movement = state.character.GetComponent<CharacterMovement>();
        anime = state.character.GetComponent<Animations>();
        attack = state.character.GetComponent<CharacterAttack>();
        hitbox = state.character.GetComponent<Hitbox>();
        anime.Crouch();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        if (!movement.isCrouching)
            state.SwitchState(state.IdleState);

        if (attack.attackID == 1 && hitbox.isAttacking)
        {
            state.SwitchState(state.LightAttackingState);
        }
        if (attack.attackID == 2 && hitbox.isAttacking)
        {
            state.SwitchState(state.HeavyAttackingState);
        }
        if (attack.attackID == 3 && hitbox.isAttacking)
        {
            state.SwitchState(state.SuperState);
        }
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}