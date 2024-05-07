using UnityEngine;
using UnityEngine.InputSystem;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal; //Input float for 2D movement
    public float speed;
    public bool isGrounded = true;
    public bool isJumping = false;
    public bool isCrouching = false;
    public bool isBlocking = false;
    public bool facingRight;

    Transform playerRotation; //Variable to control player's rotation

    public LayerMask groundLayer; //ground layer so we know if we're above ground

    public Transform groundCheck; //for checking if we're grounded.
    public float groundCheckRadius = 0.1f; //radius around groundcheck for testing 
    public float jumpForce = 20f;
    public CharacterAttack attack;
    public CharacterDataLoader Data;
    CharacterStateMachine state;
    public float moveValue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRotation = GetComponent<Transform>();
        state = GetComponent<CharacterStateMachine>();
    }

    void Update()
    {
        if (!isCrouching && !isBlocking)
        { 
            rb.velocity = new Vector2(horizontal* speed, rb.velocity.y);
            if (moveValue > 0)
            {
                state.SwitchState(state.FWalkState);
            }
            else if (moveValue < 0)
            {
                 state.SwitchState(state.BWalkState);
            }
            //Debug.Log(horizontal);
        }
        if (facingRight)
        {
            playerRotation.rotation = Quaternion.Euler(0, 180, 0);
        moveValue = horizontal;
        }
        else
        {
            playerRotation.rotation = Quaternion.Euler(0, 0, 0);
            moveValue = horizontal * -1;
        }
    }
   
    public void Movement(InputAction.CallbackContext context)
    {
            horizontal = context.ReadValue<Vector2>().x;

        if (!isBlocking)
        {
            //for crouching, is the player holding down s?
            if (context.ReadValue<Vector2>().y < -0.8)
            {
                isCrouching = true;
                state.SwitchState(state.CrouchState);
            }
            else
            {
                isCrouching = false;
            }

            if (context.ReadValue<Vector2>().y < 0)
            {
                isCrouching = true;
                state.SwitchState(state.CrouchState);
            }
            else
            {
                isCrouching = false;
            }
        }
        //}
    }

    public void Jump (InputAction.CallbackContext context)
    {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            //Debug.Log(isGrounded);

            if (context.performed && isGrounded)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                state.SwitchState(state.JumpState);
            }
    }
}
