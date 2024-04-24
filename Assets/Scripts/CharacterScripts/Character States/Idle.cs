using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Idle : CharacterBaseState
{
    Animations anime;
    GameObject character;
    public override void EnterState(CharacterStateMachine state)
    {
        anime = state.character.GetComponent<Animations>();
        character = state.character.GetComponent<GameObject>();
        anime.Idle();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        state.stateTimer = 0f;
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        state.character.
    }
}