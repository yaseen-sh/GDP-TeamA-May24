using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : CharacterBaseState
{
    Animations anime;
    CharacterAttack block;
    public override void EnterState(CharacterStateMachine state)
    {
        block = state.character.GetComponent<CharacterAttack>();
        anime = state.character.GetComponent<Animations>();
        anime.Block();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        if (!block.isBlocking)
            state.SwitchState(state.IdleState);
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}
