using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Super : CharacterBaseState
{
    Animations anime;
    CharacterMovement movement;
    Hitbox hitbox;

    private AudioSource superLine;
    public override void EnterState(CharacterStateMachine state)
    {
        hitbox = state.character.GetComponent<Hitbox>();
        superLine = state.character.GetComponentInChildren<AudioSource>();

        if (hitbox.playerTag.CompareTag("Player 1") && !GameManager.super1Full) return;
        else if (hitbox.playerTag.CompareTag("Player 2") && !GameManager.super2Full) return;

        if (hitbox.voiceLines.ContainsKey("super2"))
        {
            superLine.clip = hitbox.voiceLines["super" + Random.Range(1, 3).ToString()];
        }
        else
        {
            superLine.clip = hitbox.voiceLines["super1"];
        }
        superLine.Play();

        if (hitbox.playerTag.CompareTag("Player 1"))
        {
            GameManager.super1 = 0;
            GameManager.super1Used = true;
        }
        else if (hitbox.playerTag.CompareTag("Player 2"))
        {
            GameManager.super2 = 0;
            GameManager.super2Used = true;
        }

        movement = state.character.GetComponent<CharacterMovement>();
        anime = state.character.GetComponent<Animations>();
        anime.Super();
        GameManager.super1Full = false;
        GameManager.super2Full = false;
    }

    public override void UpdateState(CharacterStateMachine state)
    {
        if (state.stateTimer >= hitbox.totalFrameCount)
        {
            state.stateTimer = 0;
            state.SwitchState(state.IdleState);
        }
    }

    public override void OnCollisionEnter(CharacterStateMachine state)
    {
        throw new System.NotImplementedException();
    }
}