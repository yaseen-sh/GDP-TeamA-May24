using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This Script Contains a basic button Manager that loads different scenes by their name.
    When Player clicks on the button it will go to the corresponding scene.
*/
public class ButtonManager : MonoBehaviour
{

    public void TitleScreen()
    {
        Destroy(GameObject.FindGameObjectWithTag("CharManager"));
        SceneManager.LoadScene("TitleScreen");
    }
    public void MapSelect()
    {
        SceneManager.LoadScene("MapSelect");
    }
    public void CharacterSelectPvP()
    {
        SceneManager.LoadScene("CharacterSelectPvP");
    }
    public void FightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        //Application.Quit();
    }
}
