using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWalk : CharacterBaseState
{
    Animations anime;
    public override void EnterState(CharacterStateMachine state)
    {
        anime = state.character.GetComponent<Animations>();
        anime.BWalk();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
    }
}
