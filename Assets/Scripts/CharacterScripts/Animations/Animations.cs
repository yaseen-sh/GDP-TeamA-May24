using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anime;
    CharacterDataLoader data;
    
    private void Awake()
    {
        anime = GetComponent<Animator>();
    }

    public void Idle()
    {
        anime.Play("Idle");
    }

    public void FWalk()
    {
        anime.Play("forwardWalk");
    }

    public void BWalk()
    {
        anime.Play("backwardWalk");
    }

    public void Block()
    {
        anime.Play("Block");
    }

    public void Straight()
    {
        anime.Play("Straight");
    }

    public void Damaged()
    {
        anime.Play("Damaged");
    }

    public void lightAttack()
    {
        anime.Play("lightAttack");
    }

    public void heavyAttack()
    {
        anime.Play("heavyAttack");
    }

    public void Knockdown()
    {
        anime.Play("Knockdown");
    }

    public void KO()
    {
        anime.Play("KO");
    }

    public void Crouch()
    {
        anime.Play("Crouch");
    }

    public void Jump()
    {
        anime.Play("Jump");
    }
    public void Super()
    {
        anime.Play("Super");
    }
    public void Projectile()
    {
        anime.Play("Projectile");
    }
}
