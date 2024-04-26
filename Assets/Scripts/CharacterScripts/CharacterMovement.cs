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
    public bool facingRight;

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
        isStopMove = GameManager.roundOver;
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (facingRight)
        {
            
                playerRotation.rotation = Quaternion.Euler(0, 180, 0);
            //Debug.Log("Facing Right");
            //state.SwitchState(state.FWalkState);
        }
        else
        {
                playerRotation.rotation = Quaternion.Euler(0, 0, 0);
            //Debug.Log("Facing Left");
            //state.SwitchState(state.BWalkState);

        }
        if (isGrounded)
        {
            isJumping = false;
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
        Debug.Log(isStopMove);
        if (!isStopMove)
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
}
