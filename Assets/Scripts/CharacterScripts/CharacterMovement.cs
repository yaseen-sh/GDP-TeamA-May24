using UnityEngine;
using UnityEngine.InputSystem;

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
    public float moveValue;

    Transform playerRotation; //Variable to control player's rotation

    public LayerMask groundLayer; //ground layer so we know if we're above ground

    public Transform groundCheck; //for checking if we're grounded.
    public float groundCheckRadius = 0.1f; //radius around groundcheck for testing 
    public float jumpForce = 20f;
    public CharacterAttack attack;
    public CharacterDataLoader Data;
    CharacterStateMachine state;


    bool isStopMove = false;
    //public GameManager managerOfGames;
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
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
        if (isGrounded)
        {
            //Make a pause for a certain amount of time (length of jump)
            //Call SwitchState
            //Debug.Log("Grounded");
        }
    }
   
    public void Movement(InputAction.CallbackContext context)
    {
        if (!isStopMove)
        {
            horizontal = context.ReadValue<Vector2>().x;

            //for crouching, is the player holding down s?
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
    }

    public void Jump (InputAction.CallbackContext context)
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (context.performed && isGrounded && !isBlocking)
        {
            Debug.Log("Jump " + isGrounded);
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state.SwitchState(state.JumpState);
        }
    }

    public void Block(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded && !isCrouching)
        {
            isBlocking = true;
            state.SwitchState(state.BlockingState);
        }
        else
        {
            isBlocking = false;
        }
    }
}
