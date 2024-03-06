using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public Button quit;
    
    // Update is called once per frame
    void Update()
    {
        // Only Player 1 can Select and hover over buttons on the Title Screen
        if (GameObject.FindGameObjectWithTag("CursorP1") != null)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(pvpMode.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
            {
                var buttonColor = pvpMode.GetComponent<Button>().colors;
                buttonColor.normalColor = new Color(0, 0, 1, .5f);
                pvpMode.GetComponent<Button>().colors = buttonColor;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(story.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
            {
                var buttonColor = story.GetComponent<Button>().colors;
                buttonColor.normalColor = new Color(0, 0, 1, .5f);
                story.GetComponent<Button>().colors = buttonColor;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(credits.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
            {
                var buttonColor = credits.GetComponent<Button>().colors;
                buttonColor.normalColor = new Color(0, 0, 1, .5f);
                credits.GetComponent<Button>().colors = buttonColor;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(quit.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
            {
                var buttonColor = quit.GetComponent<Button>().colors;
                buttonColor.normalColor = new Color(0, 0, 1, .5f);
                quit.GetComponent<Button>().colors = buttonColor;
            }
            else 
            {
                var defaultColor = pvpMode.GetComponent<Button>().colors;
                defaultColor.normalColor = new Color(0, 0, 0, 0);
                pvpMode.GetComponent<Button>().colors = defaultColor;
                story.GetComponent<Button>().colors = defaultColor;
                credits.GetComponent<Button>().colors = defaultColor;
                quit.GetComponent<Button>().colors = defaultColor;
            }
        }
    }
}
