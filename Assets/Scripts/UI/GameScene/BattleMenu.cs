using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BattleMenu : MonoBehaviour
{
    public void ReturnToTitle(InputAction.CallbackContext context)
    {
        if (!CSSManager.gameOver) return;

        if (context.action.IsPressed())
        {
            GameManager.super1Full = false;
            GameManager.super2Full = false;
            GameManager.super1Used = false;
            GameManager.super2Used = false;
            SceneManager.LoadScene("TitleScreen");
        }
    }
    public void ReturnToCharSelect(InputAction.CallbackContext context)
    {
        if (!CSSManager.gameOver) return;

        if (context.action.IsPressed())
        {
            CSSManager.player1Fighter = null;
            CSSManager.player1Selected = false;
            CSSManager.player2Fighter = null;
            CSSManager.player2Selected = false;
            CSSManager.gameOver = false;
            GameManager.super1Full = false;
            GameManager.super2Full = false;
            GameManager.super1Used = false;
            GameManager.super2Used = false;
            SceneManager.LoadScene("CharacterSelectPvP");
        }
    }
    public void Rematch(InputAction.CallbackContext context)
    {
        if (!CSSManager.gameOver) return;

        if (context.action.IsPressed())
        {
            GameManager.super1Full = false;
            GameManager.super2Full = false;
            GameManager.super1Used = false;
            GameManager.super2Used = false;
            CSSManager.gameOver = false;
            SceneManager.LoadScene("BrawlScene");
        }
    }
}
