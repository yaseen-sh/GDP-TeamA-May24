using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationTest : MonoBehaviour
{
    public GameObject Nesteranko;
    //public GameObject Branson;
    //public GameObject Meldin;
    //public GameObject Reed;

    public void idleTest(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Idle();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void fWalkTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().FWalk();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void bWalkTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().BWalk();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void BlockTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Block();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void nesterankoStraightTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Straight();
        }
    }

    public void damagedTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Damaged();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void lightAttackTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().lightAttack();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void heavyAttackTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().heavyAttack();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void knockdownTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Knockdown();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void KOTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().KO();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void crouchTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Crouch();
            //Branson
            //Meldin
            //Reed
        }
    }

    public void jumpTest(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Nesteranko.GetComponent<NesterankoAnimation>().Jump();
            //Branson
            //Meldin
            //Reed
        }
    }
}
