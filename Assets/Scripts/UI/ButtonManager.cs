using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Script Contains a basic button Manager that loads different scenes by their name.
// When Player clicks on the button it will go to the corresponding scene.

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

    // ------------------------------------------------------
    // Character Select Buttons

    public void SelectMeldin()
    {

    }
    public void SelectGreg()
    {

    }
    public void SelectMikhail()
    {

    }
    public void SelectBranson()
    {

    }
    public void SelectBill()
    {

    }
}
