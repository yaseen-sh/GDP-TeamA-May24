using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    //This is just kind of put in from the tutorial video Dylan posted in general, we can change this later and should.
    //This is just for basic functionality and should not be final. Please give feedback as this is something I care deeply about.
    

    private CharacterController controller;
    private Vector2 playerVelocity;
    public float speed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f; //This should probably change
    public Vector2 moveInput = Vector2.zero;
    public bool jumping = false;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>(); 
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        jumping = context.ReadValue<bool>();
        jumping = context.action.triggered;
    }

    void Update()
    {
        
    }
}
