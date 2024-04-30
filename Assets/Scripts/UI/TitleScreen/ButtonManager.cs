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
    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMusic();
    }
    public void CharacterSelectPvP()
    {
        SceneManager.LoadScene("CharacterSelectPvP");
        Destroy(GameObject.FindGameObjectWithTag("CharManager"));
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMusic();
    }
    public void FightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMusic();
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMusic();
    }
    public void Story()
    {
        SceneManager.LoadScene("Story");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMusic();
    }
    public void Quit()
    {
        //Application.Quit();
    }
}
