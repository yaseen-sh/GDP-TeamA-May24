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
        //Play idle animation
        //CharacterAnim.idle();
        anime = state.character.GetComponent<Animations>();
        anime.Idle();
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