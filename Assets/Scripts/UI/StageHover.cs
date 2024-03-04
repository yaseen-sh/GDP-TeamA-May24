using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageHover : MonoBehaviour
{
    public GameObject charGrid;
    public GameObject buttonsBg;
    public TMP_Text MainText;
    public TMP_Text Background1;
    public TMP_Text Background2;
    public Image buttonImage;
    private TMP_Text[] stageNames;
    private Image[] images;

    private Sprite defaultImage;
    private string defaultText;

    private void Start()
    {
        stageNames = charGrid.GetComponentsInChildren<TMP_Text>();
        images = charGrid.GetComponentsInChildren<Image>();

        defaultImage = buttonImage.sprite;
        defaultText = MainText.text;
    }

    private void Update()
    {
        bool hovered = false;
        foreach (Image image in images)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform, Input.mousePosition))
            {
                MainText.text = image.GetComponentInChildren<TMP_Text>().text;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = image.sprite;
                hovered = true;
                break;
            }
        }

        if (!hovered)
        {
            MainText.text = defaultText;
            Background1.text = MainText.text;
            Background2.text = MainText.text;
            //defaultText = MainText.text;
            buttonImage.sprite = defaultImage;
        }
    }

    public void OnButtonClick()
    {
      //  Debug.Log("hey");
        defaultText = MainText.text;
        defaultImage = buttonImage.sprite;
    }
}
