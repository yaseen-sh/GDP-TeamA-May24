using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : CharacterBaseState
{
    CharacterMovement movement;
    Hitbox hitbox;

    Animations anime;
    private AudioSource damageLine;
    public override void EnterState(CharacterStateMachine state)
    {
        movement = state.character.GetComponent<CharacterMovement>();

        hitbox = state.character.GetComponent<Hitbox>();

        damageLine = state.character.GetComponentInChildren<AudioSource>();

        if (hitbox.voiceLines.ContainsKey("damage3"))
        {
            damageLine.clip = hitbox.voiceLines["damage" + Random.Range(1, 4).ToString()];
        }
        else
        {
            damageLine.clip = hitbox.voiceLines["damage" + Random.Range(1, 3).ToString()];
        }
        damageLine.Play();

        anime = state.character.GetComponent<Animations>();

        state.StartCo(.03f);

        anime.Damaged();
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {


        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        //after windup and winddown 

        //transition back to idle

        if (state.stateTimer >= .03f)
        {
            state.stateTimer = 0;
            state.SwitchState(state.IdleState);
        }
    }
}

