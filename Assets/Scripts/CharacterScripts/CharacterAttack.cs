using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttack : MonoBehaviour
{
    // Update is called once per frame
    public Rigidbody2D character;
    public LayerMask groundLayer; //ground layer so we know if we're above ground
    public bool isBlocking;
    public GameObject hitboxPrefab;
    public Transform hitBoxSpawnLocation;// where the hit box spawns
    public float hitboxDuration = 0f;

    private int frameCount = 0; // counts duration of current attack
    private GameObject currentHitBox;
    private SpriteRenderer hitBoxRenderer;
    
    private void Awake()
    {
        // Sets the fixed delta time to 60fps.
        Time.fixedDeltaTime = 1 / 60;
    }
    void Start()
    {
        isBlocking = false;
        InitializeHitBox();
    }
    void InitializeHitBox()
    {
        //hitBoxRenderer
        // Find hitbox renderer
        if (hitBoxRenderer == null)
            Debug.LogError("Hitbox renderer not found!");

        // Find current hitbox
        currentHitBox = hitBoxRenderer.gameObject;
        if (currentHitBox == null)
            Debug.LogError("Current hitbox not found!");
    }
    void FixedUpdate()
    {
        if (currentHitBox != null)
        {
            frameCount++;

            if (frameCount > hitboxDuration) // After hitbox duration, destroy hitbox and reset frame count
            {
                DestroyHitbox(currentHitBox);
                frameCount = 0;
            }
        }
    }

    
    
    public void AttackLight(InputAction.CallbackContext context)
    {
        Debug.Log("AttackLightCalled");
        
        if (context.performed && currentHitBox == null)
        {
            frameCount = 0; // Reset frame count

            SpawnHitbox();
            Debug.Log("light punch");
        }
    }
    float StartFrames()
    {
        return 0;
    }
    float ActiveFrames()
    {
        return 0;
    }
    float RecoveryFrames()
    {
        return 0;
    }
    float HitStunFrames()
    {
        return 0;
    }
    float BlockStunFrames()
    {
        return 0;
    }
    float attack()
    {
        int damageDealt;
        return 0;
    }
    string AttackProperty()
    {
        return "";
    }
    void SpawnHitbox()
    {
        Debug.Log("HitBoxSpawned");
        Vector3 newPosition = hitBoxSpawnLocation.position + new Vector3(1f,1f,0);
        currentHitBox = Instantiate(hitboxPrefab, newPosition, Quaternion.identity,transform);
        hitBoxRenderer.enabled = true;
        currentHitBox.SetActive(true);
        //CheckHit(); checks if hitbox triggers hurt box and applies damage.
       
    }

    void DestroyHitbox(GameObject hb)
    {
        if (hb != null)
        {
            Debug.Log("HitBox Deleted");
            Destroy(hb);
        }
    }
}
