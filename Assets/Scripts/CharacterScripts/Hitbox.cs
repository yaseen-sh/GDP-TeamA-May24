using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static CharacterController;

public class Hitbox : MonoBehaviour
{
    public LayerMask mask;

    public bool useSphere = false;

    public Vector2 hitboxSize = Vector3.one;

    public float radius = 0.5f;

    public Color inactiveColor;

    public Color collisionOpenColor;

    public Color collidingColor;
    public GameObject hitboxPrefab;
    public Transform hitBoxSpawnLocation;// where the hit box spawns
    public float hitboxDuration = 10f;
    public float hitboxPosX = 0.5f, hitboxPosY = 0.5f; //used to reposition hitbox 
    public Collider2D hitBoxCollider;
    public string actionName = "Action";// action names
    public int damage = 100;// amount of damage a attack does. for now 100

    private int frameCount = 0; // counts duration of current attack
    private GameObject currentHitBox;

    private ColliderState _state;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("HurtBox"))
        {
            checkHit(coll);
            Debug.Log(coll.gameObject.name);
        }
    }
    private void checkHit(Collider2D coll)
    {
        CharacterController Opponent = coll.gameObject.GetComponent<CharacterController>();
        Opponent.currentHealth -= damage;
        Opponent.SetPlayerHealth();
        Debug.Log("Hit Confirmed");
    }
    public void SpawnHitbox()
    {

        Debug.Log("HitBoxSpawned");
        Vector2 newPosition = hitBoxSpawnLocation.position + new Vector3(hitboxPosX, hitboxPosY); //Tweak HitBox Locations based on Attack type
        //Tweak size of prefab based off of attack
        currentHitBox = Instantiate(hitboxPrefab, newPosition, Quaternion.identity, transform);
        currentHitBox.SetActive(true);
        hitBoxCollider = currentHitBox.GetComponent<Collider2D>();
        //hitBoxRenderer.enabled = true;
        //CheckHit(); checks if hitbox triggers hurt box and applies damage.
    }

    public void DestroyHitbox(GameObject hb)
    {
        if (hb != null)
        {
            Debug.Log("HitBox Deleted");
            Destroy(hb);
        }
    }

}