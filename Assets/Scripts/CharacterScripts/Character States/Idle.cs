using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine state)
    {
        //Play idle animation
        //CharacterAnim.idle();
        Debug.Log("Idling");
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