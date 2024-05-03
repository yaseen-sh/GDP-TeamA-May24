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

    public InputDevice player1Controller;
    public InputDevice player2Controller;

    public static Dictionary<int, InputDevice> playerControllers = new Dictionary<int, InputDevice>();

    void Awake()
    {
        currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        if (GameObject.FindGameObjectsWithTag("CursorManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        if (!playerControllers.ContainsKey(1) && !playerControllers.ContainsKey(2))
        {
            var myAction = new InputAction(binding: "/*/<button>");
            myAction.performed += (action) =>
            {
                AddPlayer(action.control.device);
            };
            myAction.Enable();
        }
        else if (SceneManager.GetActiveScene().name != "BrawlScene")
        {
            string controlScheme = "Gamepad";
            if (SceneManager.GetActiveScene().name == "CharacterSelectPvP" || SceneManager.GetActiveScene().name == "StageSelect")
            {
                if (numberOfActivePlayers == 2)
                {
                    // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
                    GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{1}");
                    GameObject playerCursor2 = Resources.Load<GameObject>($"Cursors/CursorP{2}");

                    currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                    if (!playerCursor.activeInHierarchy && !playerCursor2.activeInHierarchy)
                    {
                        PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, playerControllers[1]);
                        theCursor.transform.parent = currentCanvas.transform;
                        theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
                        PlayerInput theCursor2 = PlayerInput.Instantiate(playerCursor2, -1, controlScheme, -1, playerControllers[2]);
                        theCursor2.transform.parent = currentCanvas.transform;
                        theCursor2.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                if (numberOfActivePlayers == 2)
                {

                    // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
                    GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{1}");
                    GameObject playerCursor2 = Resources.Load<GameObject>($"Cursors/CursorP{2}");

                    currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                    if (!playerCursor.activeInHierarchy && !playerCursor2.activeInHierarchy)
                    {
                        PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, playerControllers[1]);
                        theCursor.transform.parent = currentCanvas.transform;
                        theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
                        PlayerInput theCursor2 = PlayerInput.Instantiate(playerCursor2, -1, controlScheme, -1, playerControllers[2]);
                        theCursor2.transform.parent = currentCanvas.transform;
                        theCursor2.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    //StartCoroutine(ShowControllerText());
                }
                else if (numberOfActivePlayers == 1)
                {
                    GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{1}");

                    currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                    if (!playerCursor.activeInHierarchy)
                    {
                        PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, playerControllers[1]);
                        theCursor.transform.parent = currentCanvas.transform;
                        theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
            }
            else
            {
                if (numberOfActivePlayers == 2)
                {

                    // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
                    GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{1}");
                    GameObject playerCursor2 = Resources.Load<GameObject>($"Cursors/CursorP{2}");

                    currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                    if (!playerCursor.activeInHierarchy && !playerCursor2.activeInHierarchy)
                    {
                        PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, playerControllers[1]);
                        theCursor.transform.parent = currentCanvas.transform;
                        theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
                        PlayerInput theCursor2 = PlayerInput.Instantiate(playerCursor2, -1, controlScheme, -1, playerControllers[2]);
                        theCursor2.transform.parent = currentCanvas.transform;
                        theCursor2.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
                else if (numberOfActivePlayers == 1)
                {
                    GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{1}");

                    currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                    if (!playerCursor.activeInHierarchy)
                    {
                        PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, playerControllers[1]);
                        theCursor.transform.parent = currentCanvas.transform;
                        theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
            }
        }
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

        if (SceneManager.GetActiveScene().name == "BrawlScene")
            return;

        // only works for devices with controller or gamepad in the name.
        if (!device.displayName.Contains("Controller") && !device.displayName.Contains("Gamepad"))
            return;

        var playerNumberToAdd = PlayerInput.all.Count + 1;

        if (playerNumberToAdd == 2 && SceneManager.GetActiveScene().name != "TitleScreen") return;

        numberOfActivePlayers = playerNumberToAdd;
        Debug.Log("Number of Players Connected is: " + numberOfActivePlayers);
        if (playerNumberToAdd == 1) {
            player1Controller = device;
            playerControllers[playerNumberToAdd] = player1Controller;
        }
        else {
            player2Controller = device;
            playerControllers[playerNumberToAdd] = player2Controller;
        }

        string controlScheme = "Gamepad";
        if(SceneManager.GetActiveScene().name == "CharacterSelectPvP")
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
            // *** Note this utilizes the NAME of the cursor prefabs to associate the player/player # ***
            GameObject playerCursor = Resources.Load<GameObject>($"Cursors/CursorP{playerNumberToAdd}");

            currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            if (!playerCursor.activeInHierarchy)
            {
                PlayerInput theCursor = PlayerInput.Instantiate(playerCursor, -1, controlScheme, -1, device);
                theCursor.transform.parent = currentCanvas.transform;
                theCursor.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            StartCoroutine(ShowControllerText(playerNumberToAdd));
        }
        else if (SceneManager.GetActiveScene().name == "StageSelect")
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
        }
    }
    IEnumerator ShowControllerText(int playerNum)
    {
        currentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject controlText = Canvas.Instantiate(controllerConnected, currentCanvas.transform);
        controlText.GetComponent<TextMeshProUGUI>().text = "Player " + playerNum.ToString() + " Connected";
        yield return new WaitForSeconds(2f);
        controlText.GetComponent<TextMeshProUGUI>().text = "";
        Destroy(controlText);
    }


    public void OnPlayerJoin(PlayerInput input)
    {
        numberOfActivePlayers++;
        Debug.Log("There are currently " + numberOfActivePlayers + " players.");
    }

    public void OnPlayerLeft(PlayerInput input)
    {
        numberOfActivePlayers--;
        Debug.Log("There are currently " + numberOfActivePlayers + " players.");
    }
}
