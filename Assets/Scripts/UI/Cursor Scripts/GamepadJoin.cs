using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
    Script used for joining controllers. Spawns the cursor in from the resources folder. 
    Activates the cursor player input and keeps track of how many cursors are being used 
    and the limit is 2 cursors.
*/
public class GamepadJoin : MonoBehaviour
{
    [SerializeField]
    private Canvas currentCanvas;
    public static int numberOfActivePlayers { get; private set; } = 0;
    [SerializeField]
    private GameObject inputManager;

    public GameObject controllerConnected;

    public void Awake()
    {
        currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        if (inputManager == null)
        {
            inputManager = gameObject;
            //DontDestroyOnLoad(gameObject);
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
        if (SceneManager.GetActiveScene().name == "TempStageSelect") return;

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
        // only works for devices with controller or gamepad in the name.
        if (!device.displayName.Contains("Controller") && !device.displayName.Contains("Gamepad"))
            return;

        var playerNumberToAdd = PlayerInput.all.Count + 1;
        numberOfActivePlayers = playerNumberToAdd;
        Debug.Log("Number of Players Connected is: " + numberOfActivePlayers);

        string controlScheme = "Gamepad";
        if(SceneManager.GetActiveScene().name != "TitleScreen")
        {
            // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
            GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{playerNumberToAdd}");

            currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            if (!playerCursor.activeInHierarchy)
            {
                PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, device);
                theCursor.transform.parent = currentCanvas.transform;
                theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            if (numberOfActivePlayers != 2)
            {

                // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
                GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{playerNumberToAdd}");

                currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                if (!playerCursor.activeInHierarchy)
                {
                    PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, device);
                    theCursor.transform.parent = currentCanvas.transform;
                    theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
            else
            {
                StartCoroutine(ShowControllerText());
            }
        }

    }
    IEnumerator ShowControllerText()
    {
        GameObject controlText = Canvas.Instantiate(controllerConnected, currentCanvas.transform);
        controlText.GetComponent<TextMeshProUGUI>().text = "Player 2 Connected";
        yield return new WaitForSeconds(5f);
        Destroy(controlText);
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
