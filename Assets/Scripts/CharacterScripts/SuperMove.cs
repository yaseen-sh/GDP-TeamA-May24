using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI;

public class SuperMove : MonoBehaviour
{
    public GameObject superBox;
    public CharacterDataLoader data;
    private Transform spawnLocation;
    private Hitbox Opponent;
    public void InstantiateSuper()
    {
        spawnLocation.position = new Vector2(data.superAttackPosX, data.superAttackPosY);
        superBox = Instantiate(superBox, spawnLocation);

        wait(data.superAttackFrameCount);
        deleteSuper();
    }
    IEnumerator wait (float f)
    {
        yield return new WaitForSeconds (f);
    }
    public void deleteSuper()
    {
        Destroy(superBox);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("ontrigger");
        if (coll.gameObject.CompareTag("HurtBox"))
        {
            //Debug.Log(coll.gameObject.name);
            Opponent.OpponentTag.GetPlayerHealth();
            Opponent.OpponentTag.SetPlayerHealth(2,1);
            //Debug.Log("Hit Confirmed");
        }
    }

}