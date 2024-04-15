using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackingState : CharacterBaseState
{
    CharacterMovement movement;
    Hitbox hitbox;
    CharacterAttack attack;
    public override void EnterState(CharacterStateMachine state)
    {
        //Play idle animation
        //CharacterAnim.idle();
        Debug.Log("HeavyAttacking");
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}