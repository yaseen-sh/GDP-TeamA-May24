using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void MapSelect()
    {
        SceneManager.LoadScene("MapSelect");
    }
    public void CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void FightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
