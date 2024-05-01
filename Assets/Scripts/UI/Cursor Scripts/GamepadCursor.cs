using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
//using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

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
            Debug.Log(cursorSpeed);
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

        if (SceneManager.GetActiveScene().name == "StageSelect") { gameObject.GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0); }
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
                    {
                        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX();
                        titleButtons.pvpMode.GetComponent<Button>().onClick.Invoke();
                    }
                    else
                        StartCoroutine(ShowRequiredText());
                }
                // Story Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.story.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Story");
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX();
                    titleButtons.story.GetComponent<Button>().onClick.Invoke();
                }
                // Credits Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.credits.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Credits");
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX();
                    titleButtons.credits.GetComponent<Button>().onClick.Invoke();
                }
                // Controls Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.controls.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Controls");
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX();
                    titleButtons.controls.GetComponent<Button>().onClick.Invoke();
                }
                // Quit Button
                if (RectTransformUtility.RectangleContainsScreenPoint(titleButtons.quit.GetComponent<RectTransform>(), transform.position))
                {
                    Debug.Log("Quit");
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX();
                    titleButtons.quit.GetComponent<Button>().onClick.Invoke();
                }
            } 
            else if (SceneManager.GetActiveScene().name == "Credits" && gameObject.CompareTag("CursorP1")) {
                GameObject.Find("Credits").GetComponent<ScrollingText>().creditSpeedup = !GameObject.Find("Credits").GetComponent<ScrollingText>().creditSpeedup;
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    BackButton charButtons = GameObject.Find("BackButton").GetComponent<BackButton>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(charButtons.backButton.GetComponent<RectTransform>(), transform.position))
                    {
                        charButtons.backButton.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Story" && gameObject.CompareTag("CursorP1"))
            {
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    BackButton charButtons = GameObject.Find("BackButton").GetComponent<BackButton>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(charButtons.backButton.GetComponent<RectTransform>(), transform.position))
                    {
                        charButtons.backButton.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Controls" && gameObject.CompareTag("CursorP1"))
            {
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    BackButton charButtons = GameObject.Find("BackButton").GetComponent<BackButton>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(charButtons.backButton.GetComponent<RectTransform>(), transform.position))
                    {
                        charButtons.backButton.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "CharacterSelectPvP")
            {
                // Back Button
                if (gameObject.CompareTag("CursorP1"))
                {
                    BackButton charButtons = GameObject.Find("BackButton").GetComponent<BackButton>();
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
                                fighter.GetComponents<AudioSource>()[Random.Range(0, fighter.GetComponents<AudioSource>().Length)].Play(); // Selected Voice Line Plays
                            }
                            else
                            {
                                buttonColor.normalColor = new Color(0, 0, 0, 0);
                                fighter.GetComponentInChildren<Button>().colors = buttonColor;
                            }
                            //GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Selected = charSelected;
                            CSSManager.player1Selected = charSelected;
                            //GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player1Fighter = fighter.GetComponentInChildren<Image>().sprite;
                            CSSManager.player1Fighter = fighter.GetComponentInChildren<Image>().sprite;
                            CSSManager.player1FighterName = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                            CSSManager.player1Object = Resources.Load<GameObject>($"Fighters/{CSSManager.player1FighterName}");
                            CSSManager.player1Intro = SetupCharTiles.charA1Lines[fighter.GetComponentInChildren<TextMeshProUGUI>().text];
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
                            //GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Selected = charSelected;
                            CSSManager.player2Selected = charSelected;
                            //GameObject.FindGameObjectWithTag("CharManager").GetComponent<CSSManager>().player2Fighter = fighter.GetComponentInChildren<Image>().sprite;
                            CSSManager.player2Fighter = fighter.GetComponentInChildren<Image>().sprite;
                            CSSManager.player2FighterName = fighter.GetComponentInChildren<TextMeshProUGUI>().text;
                            CSSManager.player2Object = Resources.Load<GameObject>($"Fighters/{CSSManager.player2FighterName + "2"}");
                            CSSManager.player2Intro = SetupCharTiles.charA2Lines[fighter.GetComponentInChildren<TextMeshProUGUI>().text];
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
                if (CSSManager.player1Selected && CSSManager.player2Selected)
                {
                    SceneManager.LoadScene("StageSelect");
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
                else if (currentScene.name == "StageSelect") { SceneManager.LoadScene("CharacterSelectPvP"); Destroy(GameObject.FindGameObjectWithTag("CharManager")); }
                else if (currentScene.name == "Credits") { SceneManager.LoadScene("TitleScreen"); }
                else if (currentScene.name == "Story") { SceneManager.LoadScene("TitleScreen"); }
                else if (currentScene.name == "Controls") { SceneManager.LoadScene("TitleScreen"); }
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
