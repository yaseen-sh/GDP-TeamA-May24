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

    public CharacterStates state;

    /*HITBOX SPECIFIC SHIT*/
    bool m_Started = true;
    public LayerMask m_LayerMask;
    private Vector2 scaleChange, positionChange;
    private Vector2 boxSize;
    public Vector2 hitBoxSize = Vector2.one;
    private ColliderState _state;
    public CharacterDataLoader Data;
    // Start is called before the first frame update
    public enum ColliderState{ Closed, Open,Colliding}
    private void Awake()
    {
        state = GetComponent<CharacterStates>();
    }
    void Start()
    {
        // Sets the frame rate to 60fps.
        Application.targetFrameRate = 60;
        //Use this to ensure that the Gizmos are being drawn when in Play Mode
        roundStarted = false;
        boxSize = new Vector2(1.25f, 1.25f);
        SetPlayerHealth(0);
        SetSuperMeter(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // setPlayerHealth();
        //SuperMeter();
       // MyCollisions();
    }

    void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    }

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
       // if (currentHealth <= 0)
            //state.dead();
           
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
    float MovementSpeed()// variable movement speed
    {
        return 0;
    }
    float BlockMeter()// a regenerative "shield" that degrades after each hit sustained
    {
        /*
         * Do some stuff to decrement every time player blocks an attack
         */
        return currentMeter;
    }
    bool FacingRight()//if character is facing right, normal controls, else invert left right
    {
        return true; 
    }

    string status()// reports the current state of character. Used for testing/labbing mainly
    {
        string currentStatus = "Idle";
        return currentStatus;
    }
}
