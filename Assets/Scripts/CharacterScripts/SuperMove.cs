using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI;

public class SuperMove : MonoBehaviour
{
    public GameObject superBoxPrefab;
    public CharacterDataLoader data;
    private Transform spawnLocation;
    private Hitbox Opponent;
    private GameObject super;
    public void Awake()
    {
        Opponent = GetComponent<Hitbox>();
    }
    public void InstantiateSuper()
    {
        //gameObject.transform.position = new Vector2(data.superAttackPosX, data.superAttackPosY);
        super = Instantiate(superBoxPrefab, gameObject.transform);
        wait(data.superAttackFrameCount);
        
    }
    IEnumerator wait (float f)
    {
        yield return new WaitForSeconds (f);
        deleteSuper();
    }
    public void deleteSuper()
    {
       Destroy(super);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("ontrigger");
        if (coll.gameObject.CompareTag("HurtBox"))
        {
            Opponent.OpponentTag.GetPlayerHealth();
            Opponent.OpponentTag.SetPlayerHealth(2,1);
        }
        if (coll.gameObject.CompareTag("BlockBox"))
        {
            Opponent.OpponentTag.GetPlayerHealth();
            Opponent.OpponentTag.SetPlayerHealth(1, 1);
        }
    }

}