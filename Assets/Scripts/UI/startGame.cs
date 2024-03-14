using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class startGame : MonoBehaviour
{
    public GameObject hoverObj;
    private ImageHover hoverScript;
    private string stageName = "null";
    public GameObject startGameText;

    // Start is called before the first frame update
    void Start()
    {

        startGameText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        hoverObj = GameObject.Find("Buttons");
        hoverScript = hoverObj.GetComponent<ImageHover>();
        if (hoverScript.has_selected_once)
        {
            Debug.Log("passed if");
            startGameText.SetActive(true);
            stageName = hoverScript.defaultText;
        }
    }

    public void OnButtonClick()
    {
            Debug.Log("We would be loading "+stageName+" here");
        //SceneManager.LoadScene(stageName);
    }
}
