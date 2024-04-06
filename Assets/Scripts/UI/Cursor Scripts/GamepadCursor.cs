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

/*
    This should allow the user to select buttons with cursor using the gamepad left stick. 
    Both Cursors have this script attached
*/
public class GamepadCursor : MonoBehaviour
{
    private float cursorSpeed = 6;
    [SerializeField]
    private float padding = 50f;

    private Vector2 cursorMovement;

    [Header("Inportant Bools")]
    public bool moving = false;
    public bool charSelected;
    [Space]

    public GameObject playerSelection;
    public static EventHandler DoneSelectingEvent;

    [Header("Title Screen Required text")]
    public GameObject player2Required;

    [Header("BackSlider")]
    public GameObject holdSlider;
    private GameObject slider;
    private bool beingHeld = false;

    [SerializeField]
    private Sprite cursorSprite;

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
        // Checks if the back button is being Held.
        if (beingHeld)
        {
            if (slider == null) slider = Instantiate(holdSlider, transform.parent);
            slider.GetComponent<Slider>().value += (Time.deltaTime * 0.5f);
        }
        else
        {
            if (slider != null) Destroy(slider);
        }

        if (SceneManager.GetActiveScene().name == "TempStageSelect") { gameObject.GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0); }
        else { gameObject.GetComponentInChildren<Image>().sprite = cursorSprite; }
    }

    // Function Called when Cursor Moves
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
    // Function Called when the Select button is Pressed on gamepad. (Button east)
    public void OnSelectButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (SceneManager.GetActiveScene().name == "TitleScreen" && gameObject.CompareTag("CursorP1"))
            {
                SetupTitle titleButtons = GameObject.Find("TitleButtons").GetComponent<SetupTitle>();
                // Player V Player Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.pvpMode.GetComponent<RectTransform>(), transform.position))
                {
                    int players = GamepadJoin.numberOfActivePlayers;
                    if (players == 2)
                        titleButtons.pvpMode.GetComponent<Button>().onClick.Invoke();
                    else
                        StartCoroutine(ShowRequiredText());
                }
                // Story Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.story.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Story");
                    titleButtons.story.GetComponent<Button>().onClick.Invoke();
                }
                // Credits Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.credits.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Credits");
                    titleButtons.credits.GetComponent<Button>().onClick.Invoke();
                }
                // Quit Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.quit.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Quit");
                    //titleButtons.quit.GetComponent<Button>().onClick.Invoke();
                }
            } 
            else if (SceneManager.GetActiveScene().name == "Credits" && gameObject.CompareTag("CursorP1")) {
                GameObject.Find("Credits").GetComponent<ScrollingText>().creditSpeedup = !GameObject.Find("Credits").GetComponent<ScrollingText>().creditSpeedup;
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    SetupCharTiles creditButtons = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(creditButtons.backButton.GetComponent<RectTransform>(), transform.position))
                    {
                        creditButtons.backButton.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Story" && gameObject.CompareTag("CursorP1"))
            {
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    SetupCharTiles storyButtons = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(storyButtons.backButton.GetComponent<RectTransform>(), transform.position))
                    {
                        storyButtons.backButton.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "CharacterSelectPvP")
            {
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    SetupCharTiles charButtons = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(charButtons.backButton.GetComponent<RectTransform>(), transform.position))
                    {
                        charButtons.backButton.GetComponent<Button>().onClick.Invoke();
                    }
                }
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
                                fighter.GetComponent<AudioSource>().Play(); // Selected Voice Line Plays
                            }
                            else
                            {
                                buttonColor.normalColor = new Color(0, 0, 0, 0);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor;
                            }
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected = charSelected;
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Fighter = fighter.GetComponentInChildren<Image>().sprite;
                        }
                        else if (gameObject.CompareTag("CursorP2"))
                        {
                            var buttonColor2 = fighter.GetComponentInChildren<Button>().colors;
                            if (charSelected)
                            {
                                buttonColor2.normalColor = new Color(.3f, 0, 0, .5f);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor2;
                                fighter.GetComponent<AudioSource>().Play(); // Selected Voice Line Plays
                            }
                            else
                            {
                                buttonColor2.normalColor = new Color(0, 0, 0, 0);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor2;
                            }
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected = charSelected;
                            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Fighter = fighter.GetComponentInChildren<Image>().sprite;
                        }
                        return;
                    }
                }
            }
        }
    }
    // Function Called When the Start button is pressed on Gamepad
    public void OnStartButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (gameObject.CompareTag("CursorP2")) return;

            if (SceneManager.GetActiveScene().name == "CharacterSelectPvP")
            {
                Debug.Log("Start Button Pressed");
                if (GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected &&
                    GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected)
                {
                    SceneManager.LoadScene("TempStageSelect");
                }
            }
        }
    }
    // Function Called when the Back button is pressed on Gamepad (Button north)
    public void OnBackButton(InputAction.CallbackContext context)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (gameObject.CompareTag("CursorP1") && currentScene.name != "TitleScreen")
        {
            if (context.phase == InputActionPhase.Started) beingHeld = true;

            if (context.phase == InputActionPhase.Canceled) beingHeld = false;

            if (context.phase == InputActionPhase.Performed)
            {
                if (currentScene.name == "CharacterSelectPvP") { SceneManager.LoadScene("TitleScreen"); Destroy(GameObject.FindGameObjectWithTag("CharManager")); }
                else if (currentScene.name == "TempStageSelect") { SceneManager.LoadScene("CharacterSelectPvP"); Destroy(GameObject.FindGameObjectWithTag("CharManager")); }
                else if (currentScene.name == "Credits") { SceneManager.LoadScene("TitleScreen"); }
                else if (currentScene.name == "Story") { SceneManager.LoadScene("TitleScreen"); }
            }
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
