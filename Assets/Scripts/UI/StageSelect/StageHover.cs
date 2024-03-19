using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;

public class StageHover : MonoBehaviour
{
    public GameObject charGrid;
    public GameObject buttonsBg;
    public TMP_Text MainText;
    public TMP_Text Background1;
    public TMP_Text Background2;
    public Image buttonImage;
    //private TMP_Text[] stageNames;
    //private Image[] images;
    
    public static Sprite defaultImage;
    //public static bool has_selected_once;
    public static string selectedStageName;

    public TMP_Text defaultText;

    private void Start()
    {
        //stageNames = charGrid.GetComponentsInChildren<TMP_Text>();
        //images = charGrid.GetComponentsInChildren<Image>();

        defaultImage = buttonImage.sprite;
        defaultImage = null;
        //defaultText = MainText.text;
        defaultText.text = "";
        Background1.text = "";
        Background2.text = "";

        selectedStageName = "";
        //has_selected_once = false;
    }

    private void Update()
    {
        bool hovered = false;
        foreach (GameObject stage in charGrid.GetComponent<SetupStageTiles>().stageTileObjects)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(stage.GetComponent<RectTransform>(), 
                GameObject.Find("2PlayerCursor").GetComponent<VirtualMouseInput>().virtualMouse.position.value))
            {
                MainText.text = stage.GetComponentInChildren<TMP_Text>().text;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = stage.GetComponentsInChildren<Image>()[1].sprite;
                defaultImage = buttonImage.sprite;
                selectedStageName = MainText.text;
                hovered = true;
                break;
            }
            if (RectTransformUtility.RectangleContainsScreenPoint(stage.GetComponent<RectTransform>(), Input.mousePosition))
            {
                MainText.text = stage.GetComponentInChildren<TMP_Text>().text;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = stage.GetComponentsInChildren<Image>()[1].sprite;
                defaultImage = buttonImage.sprite;
                selectedStageName = MainText.text;
                hovered = true;
                break;
            }
        }
        //}
        //foreach (Image image in images)
        //{
            /*
            if (RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform, Input.mousePosition))
            {
                MainText.text = image.GetComponentInChildren<TMP_Text>().text;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = image.sprite;
                hovered = true;
                break;
            }*/
            /*
            if (RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform, GameObject.Find("2PlayerCursor").GetComponent<VirtualMouseInput>().virtualMouse.position.value))
            {
                MainText.text = image.GetComponentInChildren<TMP_Text>().text;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = image.sprite;
                hovered = true;
                break;
            }*/
        //}

        if (!hovered)
        {
            if (!startGame.hasSelectedStage)
            {
                //MainText.text = defaultText.text;
                MainText.text = "";
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                //defaultText = MainText.text;
                buttonImage.sprite = null;
            } 
            else
            {
                //MainText.text = selectedStageName;
                MainText.text = startGame.selectedStage;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = startGame.selectedImage;
            }
        }
    }
    /*
    public void StageSelect()
    {
        //defaultText.text = 
        //selectedStageName = MainText.text;
        Debug.Log(selectedStageName);
        //defaultImage = buttonImage.sprite;
        if (has_selected_once) has_selected_once = false;
        else has_selected_once = true;
    }*/
}
