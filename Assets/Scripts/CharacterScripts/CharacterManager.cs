using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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

    const float maxHealth = 1000;//should be reset to 1000 after end of round
    private float currentHealth = maxHealth;
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
        SetPlayerHealth(0);
        SetSuperMeter(0);
    }

    // Update is called once per frame
   public float GetPlayerHealth()
    {
        return currentHealth;
    }
    public void SetPlayerHealth(int damage) // playerHealth call when on hit
    {
        if (roundStarted)
            currentHealth = maxHealth;
        currentHealth -= damage;
        healthText.text = "Health: " + currentHealth.ToString();
        if (currentHealth <= 0)
            state.SwitchState(state.DeadState);

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
        superMeterText.text = "Super: " +  currentMeter.ToString();
    }
}
