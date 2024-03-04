using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    public float scrollSpeed = 50f;
    public GameObject textComponent;
    public static string TITLESCENE = "TitleScreen";

    private RectTransform rectTransform;
    private float contentWidth;
    private float canvasWidth;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //contentWidth = textComponent.preferredWidth;
       // canvasWidth = GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.width;
    }
    //TODO: when the bottom of the text crosses the top of the window, automatically go back to title scene
    void Update()
    {
        // Move the text towards left
        if(Input.GetKey(KeyCode.Space))
            rectTransform.anchoredPosition += Vector2.up * scrollSpeed*3 * Time.deltaTime;
        else
            rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(TITLESCENE);
        //    Debug.Log("Escape key was pressed");
        }

    }
}
