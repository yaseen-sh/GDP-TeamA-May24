using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine state)
    {
        Debug.Log("JumpingState");
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}
