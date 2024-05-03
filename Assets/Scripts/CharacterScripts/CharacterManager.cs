using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CharacterManager : MonoBehaviour
{
   // public CharacterAttack attack;
    public GameObject playerHurtBox;
    public GameObject playerPushBox; // Used when both players are too close to each other they will be pushed apart or swap sides.

    public TMP_Text healthText;
    public TMP_Text superMeterText;

    const float maxHealth = 3;//should be reset to 1000 after end of round
    public float currentHealth = maxHealth;
    const float minMeter = 0;
    private float currentMeter = minMeter;
    const float maxBlock = 100;//after each match the maxBlock should be reset to 100
    public float currentBlock = maxBlock;
    bool roundStarted = true;

   

    /*HITBOX SPECIFIC SHIT*/
    bool m_Started = true;
    public LayerMask m_LayerMask;
    private Vector2 scaleChange, positionChange;
    private Vector2 boxSize;
    public Vector2 hitBoxSize = Vector2.one;
    public CharacterDataLoader Data;
    // Start is called before the first frame update
    public CharacterStateMachine state;

    public float hitStunTimer;

    private void Awake()
    {
        state = GetComponent<CharacterStateMachine>();
    }
    void Start()
    {
        // Sets the frame rate to 60fps.
      
        //Use this to ensure that the Gizmos are being drawn when in Play Mode
        roundStarted = false;
        boxSize = new Vector2(1.25f, 1.25f);
        SetPlayerHealth(0,0);
        SetSuperMeter(0);
    }

    // Update is called once per frame
   public float GetPlayerHealth()
    {
        return currentHealth;
    }
    public void SetPlayerHealth(int damage, float hitStun) // playerHealth call when on hit
    {
        /*if (roundStarted)
        {
            state.SwitchState(state.IdleState);
            currentHealth = maxHealth; 
            roundStarted = false;
        }*/
        if (gameObject.CompareTag("Player 1"))
        {
            currentHealth = GameManager.health1;
        }
        else if (gameObject.CompareTag("Player 2"))
        {
            currentHealth = GameManager.health2;
        }

        if (damage > 0)
        {
            //Debug.Log(damage);
            currentHealth -= damage;
            state.SwitchState(state.DamagedState);
        }

        //currentHealth -= damage;
        if (gameObject.CompareTag("Player 1"))
        {
            GameManager.health1 = currentHealth;
            if(!GameManager.super2Full && !GameManager.super2Used) 
                GameManager.super2 += 100;
        }
        else if (gameObject.CompareTag("Player 2"))
        {
            GameManager.health2 = currentHealth;
            if (!GameManager.super1Full && !GameManager.super1Used)
                GameManager.super1 += 100;
        }

        if (currentHealth <= 0)
        {
            GameManager.roundOver = true;
            roundStarted = true;
            if (gameObject.CompareTag("Player 1"))
            {
                if (GameManager.totalLives1 == 1)
                    state.SwitchState(state.DeadState);
                else
                    state.SwitchState(state.knockdownState);
            }
            if (gameObject.CompareTag("Player 2"))
            {
                if (GameManager.totalLives2 == 1)
                    state.SwitchState(state.DeadState);
                else
                    state.SwitchState(state.knockdownState);
            }
        }
    }
    public float GetPlayerSuper()
    {
        return currentMeter;
    }
    public void SetSuperMeter(int charge) // meter used for special moves
    {
        if (roundStarted)
            currentMeter = minMeter;
        currentMeter += charge;
        //superMeterText.text = "Super: " +  currentMeter.ToString();
    }
}
