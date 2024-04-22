using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private PlayerInput player1Controls;
    private PlayerInput player2Controls;

    public CharacterDataLoader Data;

    public Slider healthBar1;
    public Slider healthBar2;

    void Awake()
    {
        //player1 = GameObject.FindGameObjectWithTag("Player 1");
        //player2 = GameObject.FindGameObjectWithTag("Player 2");
        player1Controls = PlayerInput.Instantiate(player1, 1, "Gamepad", -1, GamepadJoin.playerControllers[1]);
        player1Controls.GetComponent<SpriteRenderer>().sprite = CSSManager.player1Fighter;
        //var inputUser = player1Controls.user;
        //player1Controls.SwitchCurrentControlScheme("Gamepad");
        //InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[1], inputUser, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

        player2Controls = PlayerInput.Instantiate(player2, 2, "Gamepad", -1, GamepadJoin.playerControllers[2]);
        player2Controls.GetComponent<SpriteRenderer>().sprite = CSSManager.player2Fighter;
        //var inputUser2 = player2Controls.user;
        // player2Controls.SwitchCurrentControlScheme("Gamepad");
        //InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[2], inputUser2, InputUserPairingOptions.UnpairCurrentDevicesFromUser);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Controls.transform.position.x < player2Controls.transform.position.x)
        {
            player1Controls.GetComponent<CharacterMovement>().facingRight = true;
            player2Controls.GetComponent<CharacterMovement>().facingRight = false;
        }
        else
        {
            player1Controls.GetComponent<CharacterMovement>().facingRight = false;
            player2Controls.GetComponent<CharacterMovement>().facingRight = true;
        }
    }
}
