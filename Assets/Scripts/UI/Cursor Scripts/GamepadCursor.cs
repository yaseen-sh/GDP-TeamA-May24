using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// This should allow the user to select buttons with cursor using the gamepad left stick.

public class GamepadCursor : MonoBehaviour
{
    [SerializeField]
    private float cursorSpeed;
    [SerializeField]
    private float padding = 50f;


    private Vector2 cursorMovement;
    public bool charSelected;
    public GameObject playerSelection;
    public static EventHandler DoneSelectingEvent;
    public bool moving = false;

    [Header("Title Screen Buttons")]
    public GameObject playerVPlayerButton;
    public GameObject creditsButton;
    public GameObject player2Required;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            Instantiate(playerVPlayerButton, transform.parent);
            Instantiate(creditsButton, transform.parent);
        }
    }

    private void Update()
    {
        if (moving && !charSelected)
        {
            Vector3 newPos = new Vector3(cursorMovement.x, cursorMovement.y, 0f) * cursorSpeed;
            Vector3 temp = new Vector3(0, 0, 0);
            Vector3 worldSpace1 = Camera.main.ScreenToWorldPoint(temp);

            temp.x = Mathf.Clamp(transform.position.x, worldSpace1.x + 50, Screen.width - padding);
            temp.y = Mathf.Clamp(transform.position.y, worldSpace1.y + 50, Screen.height - padding);
            
            transform.position = new Vector3(temp.x, temp.y, 0f);
            transform.Translate(newPos);

        }
    }
    public void OnCursorMove(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Canceled)
        {
            cursorMovement = context.ReadValue<Vector2>();
            moving = true;
        }
        else  // Released button!
        {
            cursorMovement = Vector2.zero;
            moving = false;
        }
    }
    public void OnSelectButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(playerVPlayerButton.GetComponent<RectTransform>(), transform.position))
                {
                    if (GameObject.FindGameObjectWithTag("CursorManager").GetComponent<GamepadJoin>().numberOfActivePlayers == 2)
                    {
                        playerVPlayerButton.GetComponentInChildren<Button>().onClick.Invoke();
                    }
                    else
                    {
                        StartCoroutine(ShowRequiredText());
                    }
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(creditsButton.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Credits");
                    creditsButton.GetComponent<Button>().onClick.Invoke();
                }
            }
            else if (SceneManager.GetActiveScene().name == "CharacterSelectPvP")
            {
                foreach (GameObject fighter in GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>().allTiles)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(fighter.GetComponent<RectTransform>(), transform.position))
                    {
                        if (charSelected) charSelected = false;
                        else charSelected = true;

                        if (gameObject.CompareTag("CursorP1"))
                        {
                            var buttonColor = fighter.GetComponentInChildren<Button>().colors;
                            if (charSelected)
                            {
                                buttonColor.normalColor = new Color(0, 0, .2f, .5f);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor;
                            }
                            else
                            {
                                buttonColor.normalColor = new Color(0, 0, 0, 0);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor;
                            }
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected = charSelected;
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Fighter = fighter.GetComponentInChildren<Image>().sprite;
                        }
                        else if (gameObject.CompareTag("CursorP2"))
                        {
                            var buttonColor2 = fighter.GetComponentInChildren<Button>().colors;
                            if (charSelected)
                            {
                                buttonColor2.normalColor = new Color(.5f, 0, 0, .5f);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor2;
                            }
                            else
                            {
                                buttonColor2.normalColor = new Color(0, 0, 0, 0);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor2;
                            }
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected = charSelected;
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Fighter = fighter.GetComponentInChildren<Image>().sprite;
                        }
                        return;
                    }
                }
            }
        }
    }

    public void OnStartButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Start Button Pressed");
            if (GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected && 
                GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected)
            {
                SceneManager.LoadScene("StageSelect");   
            }
        }
    }
    public void OnBackButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Back Button Pressed");
            SceneManager.LoadScene("TitleScreen");
        }
    }

    // Enumerator that shows that 2 players is Required to play PvP mode
    IEnumerator ShowRequiredText()
    {
        GameObject text = Instantiate(player2Required, transform.parent);
        text.GetComponent<TextMeshProUGUI>().text = "A Second Player is Required";
        yield return new WaitForSeconds(5f);
        Destroy(text);
    }
}
