using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
    Script the sets up the title screen buttons and is used to detect if the gamepad cursor is over the buttons
    Cursor Highlights the buttons when the cursor is hovered over the button
    Highlights go away after cursor stops hovering.
*/
public class SetupTitle : MonoBehaviour
{
    [Header("Title Screen Buttons")]
    public Button pvpMode;
    public Button story;
    public Button credits;
    public Button controls;
    public Button quit;

    public TextMeshProUGUI pressText;
    private bool showText = false;

    private void Start()
    {
        CSSManager.player1Fighter = null;
        CSSManager.player1Selected = false;
        CSSManager.player2Fighter = null;
        CSSManager.player2Selected = false;
        CSSManager.gameOver = false;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("CursorP1") == null && !showText)
        {
            StartCoroutine(PressAnyButton());
        }

        if (GamepadJoin.numberOfActivePlayers == 1)
        {
            if (GameObject.FindGameObjectWithTag("CursorP1") != null && SceneManager.GetActiveScene().name == "TitleScreen")
            {
                pressText.text = "";
                if (RectTransformUtility.RectangleContainsScreenPoint(pvpMode.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                {
                    var buttonColor = pvpMode.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    pvpMode.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = pvpMode.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    pvpMode.GetComponent<Button>().colors = buttonColor;
                }

                if (RectTransformUtility.RectangleContainsScreenPoint(story.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                {
                    var buttonColor = story.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    story.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = story.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    story.GetComponent<Button>().colors = buttonColor;
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(credits.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                {
                    var buttonColor = credits.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    credits.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = credits.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    credits.GetComponent<Button>().colors = buttonColor;
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(controls.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                {
                    var buttonColor = controls.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    controls.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = controls.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    controls.GetComponent<Button>().colors = buttonColor;
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(quit.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
                {
                    var buttonColor = quit.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    quit.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = quit.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    quit.GetComponent<Button>().colors = buttonColor;
                }
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("CursorP1") != null && GameObject.FindGameObjectWithTag("CursorP2") != null && SceneManager.GetActiveScene().name == "TitleScreen")
            {
                pressText.text = "";
                if (RectTransformUtility.RectangleContainsScreenPoint(pvpMode.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position) ||
                    RectTransformUtility.RectangleContainsScreenPoint(pvpMode.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                {
                    var buttonColor = pvpMode.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    pvpMode.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = pvpMode.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    pvpMode.GetComponent<Button>().colors = buttonColor;
                }

                if (RectTransformUtility.RectangleContainsScreenPoint(story.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position) ||
                    RectTransformUtility.RectangleContainsScreenPoint(story.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                {
                    var buttonColor = story.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    story.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = story.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    story.GetComponent<Button>().colors = buttonColor;
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(credits.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position) ||
                    RectTransformUtility.RectangleContainsScreenPoint(credits.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                {
                    var buttonColor = credits.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    credits.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = credits.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    credits.GetComponent<Button>().colors = buttonColor;
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(controls.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position) ||
                    RectTransformUtility.RectangleContainsScreenPoint(controls.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                {
                    var buttonColor = controls.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    controls.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = controls.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    controls.GetComponent<Button>().colors = buttonColor;
                }
                if (RectTransformUtility.RectangleContainsScreenPoint(quit.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position) ||
                    RectTransformUtility.RectangleContainsScreenPoint(quit.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
                {
                    var buttonColor = quit.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 1, .2f);
                    quit.GetComponent<Button>().colors = buttonColor;
                }
                else
                {
                    var buttonColor = quit.GetComponent<Button>().colors;
                    buttonColor.normalColor = new Color(0, 0, 0, 0);
                    quit.GetComponent<Button>().colors = buttonColor;
                }
            }
        }
    }
    IEnumerator PressAnyButton()
    {
        pressText.text = "Press Any Button";
        showText = true;
        yield return new WaitForSeconds(1f);
        pressText.text = "";
        yield return new WaitForSeconds(1f);
        showText = false;
    }
}

