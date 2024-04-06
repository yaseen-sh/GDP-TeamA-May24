using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void IState.OnUpdate()
    {
        throw new System.NotImplementedException();

    }
    void IState.OnDisable()
    {

    }

    void IState.OnEnable()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnIdle()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnWalk()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnJump()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnMidAir()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnAttacking()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnBlocking()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnHitStunned()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnDamaged()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnWakeUp()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnKnockDown()
    {
        throw new System.NotImplementedException();
    }

    void IState.OnDead()
    {
        throw new System.NotImplementedException();
    }
}