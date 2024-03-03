using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Script Contains a basic button Manager that loads different scenes by their name.
// When Player clicks on the button it will go to the corresponding scene.

public class ButtonManager : MonoBehaviour
{
    private bool p1Select;
    private bool p2Select;

    public void Start()
    {
        p1Select = false;
        p2Select = false;
    }

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
    // Character Select Buttons - Probably Don't Need
    /*
    public void SelectMeldin()
    {
        Debug.Log("Meldin & Medo");
        Sprite meldin = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>().fighters[0].charImage;
        /*GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Fighter = meldin;

        if (RectTransformUtility.RectangleContainsScreenPoint(meldin.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
        {
            //if (p1Select) p1Select = false;
            //else p1Select = true;

            //Debug.Log(p1Select);
            //GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected = p1Select;
            //GameObject.FindGameObjectWithTag("CursorP1").GetComponent<GamepadCursor>().charSelected = 
            return;
        }
        if (RectTransformUtility.RectangleContainsScreenPoint(meldin.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
        {
            //if (p2Select) p2Select = false;
            //else p2Select = true;

            //GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected = p2Select;
            return;
        }
    }
    public void SelectBranson()
    {
        Debug.Log("Branson");
        GameObject branson = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>().allTiles[1];

        if (RectTransformUtility.RectangleContainsScreenPoint(branson.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
        {
            if (p1Select) p1Select = false;
            else p1Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected = p1Select;
            return;
        }
        if (RectTransformUtility.RectangleContainsScreenPoint(branson.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
        {
            if (p2Select) p2Select = false;
            else p2Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected = p2Select;
            return;
        }
    }
    public void SelectGreg()
    {
        Debug.Log("GREG");
        GameObject greg = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>().allTiles[2];

        if (RectTransformUtility.RectangleContainsScreenPoint(greg.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
        {
            if (p1Select) p1Select = false;
            else p1Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected = p1Select;
            return;
        }
        if (RectTransformUtility.RectangleContainsScreenPoint(greg.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
        {
            if (p2Select) p2Select = false;
            else p2Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected = p2Select;
            return;
        }
    }
    public void SelectMikhail()
    {
        Debug.Log("NESTY");
        GameObject nesty = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>().allTiles[3];

        if (RectTransformUtility.RectangleContainsScreenPoint(nesty.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
        {
            if (p1Select) p1Select = false;
            else p1Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected = p1Select;
            return;
        }
        if (RectTransformUtility.RectangleContainsScreenPoint(nesty.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
        {
            if (p2Select) p2Select = false;
            else p2Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected = p2Select;
            return;
        }
    }
    public void SelectBill()
    {
        Debug.Log("Bill");
        GameObject bill = GameObject.FindGameObjectWithTag("CharGrid").GetComponent<SetupCharTiles>().allTiles[4];

        if (RectTransformUtility.RectangleContainsScreenPoint(bill.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP1").transform.position))
        {
            if (p1Select) p1Select = false;
            else p1Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player1Selected = p1Select;
            return;
        }
        if (RectTransformUtility.RectangleContainsScreenPoint(bill.GetComponent<RectTransform>(), GameObject.FindGameObjectWithTag("CursorP2").transform.position))
        {
            if (p2Select) p2Select = false;
            else p2Select = true;

            GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharManager>().player2Selected = p2Select;
            return;
        }
    }*/
}
