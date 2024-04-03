using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
IEnumerator ComboResetTime()// amount of time to reset combo
{
    yield return new WaitForSeconds(1);

    //movesManager.PlayMove(Keys); //Run the move from the list
    //Keys.Clear(); //Empty the list
}
*/
public enum PlayerControllerState { Idle, Walk, Jump, MidAir, Attacking, Blocking, HitStunned, BlockStunned, Damaged,
    WakeUp, KnockDowned, Dead };
//public CharacterDataLoader Data;
//Context
   
public class CharacterStates : MonoBehaviour
{
    //concrete state
    private PlayerControllerState _state;

    private void Update()
    {
        switch(_state)
        {
            case PlayerControllerState.Idle:
                break;
            case PlayerControllerState.Walk:
                break;
            case PlayerControllerState.Jump:
                break;
            case PlayerControllerState.MidAir:
                break;
            case PlayerControllerState.Damaged:
                break;
            case PlayerControllerState.Attacking:
                break;
            case PlayerControllerState.Blocking: 
                break;
            case PlayerControllerState.HitStunned: 
                break;
            case PlayerControllerState.BlockStunned:
                break;
            case PlayerControllerState.WakeUp: 
                break;
            case PlayerControllerState.KnockDowned:
                break;
            case PlayerControllerState.Dead: 
                break;    
        }
        _state = PlayerControllerState.Idle;
    }

    /*
    public CharacterStates(State state)
    {
        this.TransitionTo(state);
    }
    
    public void TransitionTo(State state)// Used to move characters from state to state
    {
        Debug.Log("State Transitioned to: " + state);
        this._state = state;
        this._state.SetContext(this);
    }
    */
    [SerializeField] List<KeyCode> Keys = new List<KeyCode>();
    [SerializeField] Text controlsTestText; // used for printing out buttons pressed

    //MovesManager movesManager;
}
