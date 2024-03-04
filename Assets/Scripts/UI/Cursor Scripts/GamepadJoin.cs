using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

public class GamepadJoin : MonoBehaviour
{
    [SerializeField]
    private Canvas currentCanvas;
    public int numberOfActivePlayers { get; private set; } = 0;
    private GameObject inputManager;

    public void Awake()
    {
        if (inputManager == null)
        {
            inputManager = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        var myAction = new InputAction(binding: "/*/<button>");
        myAction.performed += (action) =>
        {
            AddPlayer(action.control.device);
        };
        myAction.Enable();
    }
    void AddPlayer(InputDevice device)
    {
        foreach (var player in PlayerInput.all)
        {
            foreach (var playerDevice in player.devices)
            {
                if (device == playerDevice)
                {
                    return;
                }
            }
        }

        if (!device.displayName.Contains("Controller") && !device.displayName.Contains("Gamepad"))
            return;

        var playerNumberToAdd = PlayerInput.all.Count + 1;
        numberOfActivePlayers = playerNumberToAdd;

        string controlScheme = "Gamepad";

        // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
        GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{playerNumberToAdd}");


        if (!playerCursor.activeInHierarchy)
        {
            PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, device);
            theCursor.transform.parent = currentCanvas.transform;
            theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }



    public void OnPlayerJoin(PlayerInput input)
    {
        numberOfActivePlayers = PlayerInput.all.Count;
        Debug.Log("There are currently " + numberOfActivePlayers + " players.");
    }

    public void OnPlayerLeft(PlayerInput input)
    {
        numberOfActivePlayers = PlayerInput.all.Count;
        Debug.Log("There are currently " + numberOfActivePlayers + " players.");
    }
}
