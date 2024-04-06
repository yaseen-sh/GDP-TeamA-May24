using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button backButton;

    void Update()
    {
        // For the back button hover
        if (GameObject.FindGameObjectWithTag("CursorP1") != null)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(backButton.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
            {
                var buttonColor = backButton.GetComponent<Button>().colors;
                buttonColor.normalColor = new Color(0, 0, 1, .5f);
                backButton.GetComponent<Button>().colors = buttonColor;
            }
            else
            {
                var defaultColor = backButton.GetComponent<Button>().colors;
                defaultColor.normalColor = new Color(0, 0, 0, 0);
                backButton.GetComponent<Button>().colors = defaultColor;
            }
        }
    }
}
