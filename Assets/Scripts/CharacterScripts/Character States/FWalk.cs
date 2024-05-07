using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWalk : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    CharacterAttack attack;
    Hitbox hitbox;
    public override void EnterState(CharacterStateMachine state)
    {
        anime = state.character.GetComponent<Animations>();
        movement = state.character.GetComponent<CharacterMovement>();
        attack = state.character.GetComponent<CharacterAttack>();
        hitbox = state.character.GetComponent<Hitbox>();
        anime.FWalk();
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
        if (attack.attackID == 1 && hitbox.isAttacking)
        {
            state.SwitchState(state.LightAttackingState);
        }
        if (attack.attackID == 2 && hitbox.isAttacking)
        {
            state.SwitchState(state.HeavyAttackingState);
        }
        if(attack.attackID == 3 && hitbox.isAttacking)
        {
            state.SwitchState(state.SuperState);
        }
    }
}
