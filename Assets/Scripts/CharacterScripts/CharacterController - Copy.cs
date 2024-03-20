using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterController : MonoBehaviour
{
   // public CharacterAttack attack;
    public GameObject playerHurtBox;
    public GameObject playerPushBox; // Used when both players are too close to each other they will be pushed apart or swap sides.

    public TMP_Text healthText;
    public TMP_Text superMeterText;

    const float maxHealth = 1000;//should be reset to 1000 after end of round
    public float currentHealth = maxHealth;


    /*HITBOX SPECIFIC SHIT*/
    bool m_Started;
    public LayerMask m_LayerMask;
    private Vector2 scaleChange, positionChange;
    private Vector2 boxSize;
    public Vector2 hitBoxSize = Vector2.one;
    private ColliderState _state;
    // Start is called before the first frame update
    public enum ColliderState{ Closed, Open,Colliding}
    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode
        m_Started = true;
        boxSize = new Vector2(1.25f, 1.25f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Sets the fixed delta time to 60fps.
        Time.fixedDeltaTime = 1 / 60;
        setPlayerHealth();
        SuperMeter();
        MyCollisions();
    }

    void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.75f, 0.0f, 0.0f, 0.75f);
        
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale/2);
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawCube(Vector2.zero, new Vector2(boxSize.x * 1.25f, boxSize.y * 2.2f));//CHANGE VALUES FOR SPRITES
        
    }

    public void setPlayerHealth() // playerHealth
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }

    float SuperMeter() // meter used for special moves
    {
        const float minMeter = 0;//after each match the minMeter should be reset to 0
        float currentMeter = minMeter;
        superMeterText.text = "Super: " +  currentMeter.ToString();
        return currentMeter;
    }
    float MovementSpeed()// variable movement speed
    {
        return 0;
    }
    float BlockMeter()// a regenerative "shield" that degrades after each hit sustained
    {
        const float minMeter = 100;//after each match the minMeter should be reset to 100
        float currentMeter = minMeter;
        return currentMeter;
    }
    bool FacingRight()//if character is facing right, normal controls, else invert left right
    {
        return true; 
    }

    string status()// reports the current state of character. Used for testing/labbing mainly
    {
        string currentStatus = "Idle";
        return currentStatus;
    }
}
