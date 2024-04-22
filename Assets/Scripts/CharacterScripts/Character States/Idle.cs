using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Idle : CharacterBaseState
{
    Animations anime;
    GameObject character;
    public void awake()
    {
        
    }
    public override void EnterState(CharacterStateMachine state)
    {
        anime = state.character.GetComponent<Animations>();
        anime.Idle();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        state.stateTimer = 0f;
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}