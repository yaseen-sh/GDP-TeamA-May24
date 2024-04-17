using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationTest : MonoBehaviour
{
    public GameObject Nesteranko;
    public GameObject Branson;
    //public GameObject Meldin;
    //public GameObject Reed;

    public void idleTest(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Nesteranko.GetComponent<Animations>().Idle();
            Branson.GetComponent<Animations>().Idle();
            //Meldin
            //Reed
        }
    }

    public void fWalkTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().FWalk();
            Branson.GetComponent<Animations>().FWalk();
            //Meldin
            //Reed
        }
    }

    public void bWalkTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().BWalk();
            Branson.GetComponent<Animations>().BWalk();
            //Meldin
            //Reed
        }
    }

    public void BlockTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().Block();
            Branson.GetComponent<Animations>().Block();
            //Meldin
            //Reed
        }
    }

    public void nesterankoStraightTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().Straight();
        }
    }

    public void damagedTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().Damaged();
            Branson.GetComponent<Animations>().Damaged();
            //Meldin
            //Reed
        }
    }

    public void lightAttackTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().lightAttack();
            Branson.GetComponent<Animations>().lightAttack();
            //Meldin
            //Reed
        }
    }

    public void heavyAttackTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().heavyAttack();
            Branson.GetComponent<Animations>().heavyAttack();
            //Meldin
            //Reed
        }
    }

    public void knockdownTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().Knockdown();
            Branson.GetComponent<Animations>().Knockdown();
            //Meldin
            //Reed
        }
    }

    public void KOTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().KO();
            Branson.GetComponent<Animations>().KO();
            //Meldin
            //Reed
        }
    }

    public void crouchTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().Crouch();
            Branson.GetComponent<Animations>().Crouch();
            //Meldin
            //Reed
        }
    }

    public void jumpTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<Animations>().Jump();
            Branson.GetComponent<Animations>().Jump();
            //Meldin
            //Reed
        }
    }
}
