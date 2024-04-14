using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Used to push characters apart from each other so they cant stand on top of each other

public class Pushbox : MonoBehaviour
{
    float repelForce = 100f;
    Rigidbody2D parent;
    Rigidbody2D otherRb;
    Vector2 repelDirection1;
    Vector2 repelDirection2;
    CharacterMovement movement;
    private void Awake()
    {
        parent = GetComponentInParent<Rigidbody2D>();
    }
    private IEnumerator coroutine;
    private void OnTriggerStay2D(Collider2D other)
    {
        otherRb = other.GetComponentInParent<Rigidbody2D>();
        if (other.CompareTag("Pushbox"))
        { 
            Repel(other.transform, otherRb);
        }
    }
    // every 2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void Repel(Transform otherTransform, Rigidbody2D otherRb)
    {
        coroutine = WaitAndPrint(.1f); // waits for 10 frames to push
        movement = GetComponentInParent<CharacterMovement>();

        StartCoroutine(coroutine);
        if (movement.facingRight && !movement.isJumping)//right
        {
           
           // Debug.Log("1");
            repelDirection1 = transform.position - otherTransform.position;
            repelDirection2 = transform.position + otherTransform.position;
            parent.AddForce(repelDirection1.normalized * repelForce);
            otherRb.AddForce(repelDirection2.normalized * repelForce);
        }
        else if (!movement.facingRight && !movement.isJumping)//left
        {
           // Debug.Log("2");
            repelDirection1 = transform.position + otherTransform.position;
            repelDirection2 = transform.position - otherTransform.position;
            parent.AddForce(repelDirection1.normalized * repelForce);
            otherRb.AddForce(repelDirection2.normalized * repelForce);
        }
        
    }
}
