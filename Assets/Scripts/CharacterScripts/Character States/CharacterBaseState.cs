using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState(CharacterStateMachine state);
    public abstract void UpdateState(CharacterStateMachine state);
    public abstract void OnCollisionEnter(CharacterStateMachine state);

}