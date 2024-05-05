using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI;

public class SuperMove : MonoBehaviour
{
    public GameObject superBoxPrefab;
    public CharacterDataLoader data;
    private Transform spawnLocation;
    private CharacterManager OpponentTag;
    private GameObject super;
    private Hitbox hitbox;
    private void Awake()
    {
        hitbox = GetComponent<Hitbox>();
        if (gameObject.tag == "Player 1")
        {
            OpponentTag = GameObject.FindGameObjectWithTag("Player 2").GetComponent<CharacterManager>();
        }
        else
        {
            OpponentTag = GameObject.FindGameObjectWithTag("Player 1").GetComponent<CharacterManager>();
        }
    }
    public void InstantiateSuper()
    {
        //gameObject.transform.position = new Vector2(data.superAttackPosX, data.superAttackPosY);
        super = Instantiate(superBoxPrefab, gameObject.transform);
        StartCoroutine(wait(data.superAttackFrameCount));
    }
    
    IEnumerator wait (float f)
    {
        yield return new WaitForSeconds (f);
        Destroy(super);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("ontrigger");
        if (coll.gameObject.CompareTag("HurtBox") && hitbox.isAttacking == true)
        {
            //Debug.Log(coll.gameObject.name);
            OpponentTag.GetPlayerHealth();
            OpponentTag.SetPlayerHealth(2,1);
            //Debug.Log("Hit Confirmed");
        }
        else if (coll.gameObject.CompareTag("BlockBox"))
        {
            OpponentTag.GetPlayerHealth();
            OpponentTag.SetPlayerHealth(1, 1);
        }
    }

}