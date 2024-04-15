using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine state)
    {
        //Play crouch animation
        //CharacterAnim.idle();
        Debug.Log("CrouchingState");
        //change the hitbox accordingly
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