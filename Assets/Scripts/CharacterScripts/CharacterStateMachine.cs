using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
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
    public class CharacterStateMachine : MonoBehaviour
    {
        protected CharacterController player;
        protected CharacterStateMachine stateMachine;
        protected Animator animationController;
        protected string animationName;

        protected bool isExitingState;
        protected bool isAnimationFinished;
        protected float startTime;
        private IState _CurrentState;
        public CharacterStateMachine(CharacterController _player, CharacterStateMachine _stateMachine, Animator _animationController, string _animationName)
        {
            player = _player;
            stateMachine = _stateMachine;
            animationController = _animationController;
            animationName = _animationName;
        }
        public void ChangeState(IState newState)
        {
            _CurrentState = newState;
        }
        public IState CurrentState { get; private set; }
        //concrete state
        public event Action<IState> stateChanged;


    }
    public interface IState
    {
        
    }