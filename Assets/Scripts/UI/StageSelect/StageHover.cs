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
    public static AudioClip stageSong;

    private void Start()
    {
        //stageNames = charGrid.GetComponentsInChildren<TMP_Text>();
        //images = charGrid.GetComponentsInChildren<Image>();

        defaultImage = buttonImage.sprite;
        buttonImage.enabled = false;

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
                buttonImage.enabled = true;
                selectedStageName = MainText.text;
                stageSong = stage.GetComponent<AudioSource>().clip;
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
                buttonImage.enabled = true;
                selectedStageName = MainText.text;
                stageSong = stage.GetComponent<AudioSource>().clip;
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
                MainText.text = "";
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = null;
                buttonImage.enabled = false;
            } 
            else
            {
                MainText.text = startGame.selectedStage;
                Background1.text = MainText.text;
                Background2.text = MainText.text;
                buttonImage.sprite = startGame.selectedImage;
            }
        }
    }
}
