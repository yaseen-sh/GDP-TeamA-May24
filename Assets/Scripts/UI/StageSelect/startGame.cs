using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public GameObject hoverObj;
    private StageHover hoverScript;
    //private string stageName = "null";
    public GameObject startGameText;

    public static string selectedStage;
    public static Sprite selectedImage;
    private string prevSelectedStage;
    public static bool hasSelectedStage = false;

    // Start is called before the first frame update
    void Start()
    {
        hoverObj = GameObject.Find("Buttons");
        hoverScript = hoverObj.GetComponent<StageHover>();
        startGameText.GetComponentInChildren<TextMeshProUGUI>().text = "";
        selectedStage = "";
        hasSelectedStage = false;
        prevSelectedStage = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSelectedStage)
            startGameText.GetComponentInChildren<TextMeshProUGUI>().text = "Start Game";
        else
            startGameText.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    public void StageSelect()
    {
        selectedStage = StageHover.selectedStageName;
        selectedImage = StageHover.defaultImage;
        Debug.Log(selectedStage);
        if (prevSelectedStage == selectedStage)
        {
            if (hasSelectedStage) hasSelectedStage = false;
            else hasSelectedStage = true;
        } 
        else
        {
            hasSelectedStage = true;
            prevSelectedStage = selectedStage;
        }
    }

    public void LoadStage()
    {
        Debug.Log("We would be loading "+selectedStage+" here");
        if (GameObject.Find("AudioManager") != null)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMusic();
            Destroy(GameObject.Find("AudioManager"));
        }
        SceneManager.LoadScene(selectedStage);
    }
}
