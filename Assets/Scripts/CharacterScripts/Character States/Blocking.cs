using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : CharacterBaseState
{
    Animations anime;
    CharacterAttack block;
    CharacterManager manager;

    public override void EnterState(CharacterStateMachine state)
    {
        manager = state.character.GetComponent<CharacterManager>();
        block = state.character.GetComponent<CharacterAttack>();
        anime = state.character.GetComponent<Animations>();
        anime.Block();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
       //super 1 damage
       //decrease block meter
      
    }

    public override void UpdateState(CharacterStateMachine state)
    {
       // throw new System.NotImplementedException();
    }
}
