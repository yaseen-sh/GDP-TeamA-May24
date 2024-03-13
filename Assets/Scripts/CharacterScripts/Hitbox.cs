using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI;

public class Hitbox : MonoBehaviour
{
    public LayerMask mask;

    public bool useSphere = false;

    public Vector2 hitboxSize = Vector3.one;

    public float radius = 0.5f;
    public GameObject hitboxPrefab;
    public Transform hitBoxSpawnLocation;// where the hit box spawns
    public float hitboxDuration = 10f;
    public float hitboxPosX = 0.5f, hitboxPosY = 0.5f; //used to reposition hitbox 
    public Collider2D hitBoxCollider;
    public string actionName = "Action";// action names
    public int damage = 100;// amount of damage a attack does. for now 100

    private int frameCount = 0; // counts duration of current attack
    private float timer = .1f;
    public GameObject currentHitBox;
    private Vector2 scaleChange;
    public GameObject hitBoxChild;
    public CharacterManager Opponent;
    public CharacterManager playerTag;
    public bool isAttacking = false;
    //private ColliderState _state;


    //Character Loader
    public int lightAttackDamage = 0;
    public float lightAttackPosY = 0;
    public float lightAttackPosX = 0;
    public float lightAttackFrameCount = 0;
    public float lightAttackHitboxScale = 0;

    public int heavyAttackDamage = 0;
    public float heavyAttackPosY = 0;
    public float heavyAttackPosX = 0;
    public float heavyAttackFrameCount = 0;
    public Vector2 heavyAttackHitboxScale = new Vector2 (0f,0f);





    public CharacterMovement movement;
    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }
    private void Update()
    {
        
        if (currentHitBox != null)
        {
            
            //framecount -= time.deltatime;
            //if(frame <= 0; framecount = 0)
            //if (attackHappened then start frame counter
            //setup for each
            //time.deltatime
            frameCount++;
            timer -= Time.deltaTime;
            //Debug.Log(timer);
            if (timer <= 0f) // After hitbox duration, destroy hitbox and reset frame count
            {
                //Debug.Log("Frames per second: " + frameCount);
                DestroyHitbox(currentHitBox);
                frameCount = 0;
                isAttacking = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("ontrigger");
        if (coll.gameObject.CompareTag("HurtBox")&& isAttacking == true)
        { 
            //Debug.Log(coll.gameObject.name);
            
            Opponent.currentHealth -= damage;
            Opponent.SetPlayerHealth();
            //Debug.Log("Hit Confirmed");
        }
    }
    public void SpawnHitbox(int attackType)
    {
        //Debug.Log("HitBoxSpawned");
        switch (attackType)
        {
            //attacktype Light
            case 1:
                damage = lightAttackDamage;
                //set hitbox parameters
                timer = lightAttackFrameCount;
                if (movement.facingRight == true)
                {
                    Debug.Log("FacingRightLightAttack");
                    hitboxPosX = lightAttackPosX;
                    hitboxPosY = lightAttackPosY;
                    scaleChange = heavyAttackHitboxScale;
                }
                else
                {
                    Debug.Log("FacingLeftLightAttack");
                    hitboxPosX = -lightAttackPosX;
                    hitboxPosY = lightAttackPosY;
                    scaleChange = heavyAttackHitboxScale;
                }
            break;
            //attacktype heavy
            case 2:
                damage = 100;
                if (movement.facingRight == true)
                {
                    Debug.Log("FacingRightHeavyAttack");
                }
                else
                {
                    Debug.Log("FacingLeftHeavyAttack");
                }
                break;
            //attacktype etc
            case 3:
                if (movement.facingRight == true)
                {
                    Debug.Log("FacingRightLightAttack");
                }
                else
                {
                    Debug.Log("FacingLeftLightAttack");
                }
                break;
        }
            
                                             //Tweak size of prefab based off of attack
        if (hitBoxChild.transform.childCount <= 0 )
        {
            //Check for the same hitbox hit 
            Vector2 newPosition = hitBoxSpawnLocation.position + new Vector3(hitboxPosX, hitboxPosY); //Tweak HitBox Locations based on Attack type
            currentHitBox = Instantiate(hitboxPrefab, newPosition, Quaternion.identity, hitBoxSpawnLocation);
            currentHitBox.transform.localScale = scaleChange;
            currentHitBox.transform.parent = hitBoxChild.transform;
            currentHitBox.SetActive(true);
            hitBoxCollider = currentHitBox.GetComponent<Collider2D>();
            //hitBoxRenderer.enabled = true;
        }
      
    }

    public void DestroyHitbox(GameObject hb)
    {

        if (hb != null)
        {
            hb.SetActive(false);
            Destroy(hb);
            //Debug.Log("Hitbox Destroyed");
        }
    }

}