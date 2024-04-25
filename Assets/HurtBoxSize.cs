using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxSize : MonoBehaviour
{
    private BoxCollider2D hurtBox;
    private CharacterMovement state;
    private Vector2 hurtboxMoveDown = new Vector2(0f, -.3f);
    private Vector2 hurtboxMoveBack = new Vector2(0f, .3f);
    private bool hasMovedDown = false;
    private bool hasMovedUp = true;

    // Start is called before the first frame update
    void Start()
    {
        //getting the state component
        state = GetComponentInParent<CharacterMovement>();

        //Getting the hurtBox
        hurtBox = GetComponent<BoxCollider2D>();

        //if you forget to add a hurtBox
        if (hurtBox != null)
        {
            // Box Collider component found, you can now use it
            Debug.Log("Box Collider found on this object!");
        }
        else
        {
            Debug.LogError("Box Collider not found on this object!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state.isCrouching)
        {
            ChangeHurtBox(1f, 0.5474358f);
            if (!hasMovedDown)
            {
                hurtBox.offset += hurtboxMoveDown;
                hasMovedDown = true;
                hasMovedUp = false;
            }

        }
        else
        {
            ChangeHurtBox(1f, 1f);
            if (!hasMovedUp)
            {
                hurtBox.offset += hurtboxMoveBack;
                hasMovedUp = true;
                hasMovedDown = false;
            }

        }
    }

    private void ChangeHurtBox(float x, float y)
    {
        hurtBox.size = new Vector2(x, y);
    }
}
