using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Fighters")]
    public GameObject player1;
    public GameObject player2;

    private PlayerInput player1Controls;
    private PlayerInput player2Controls;

    public CharacterDataLoader Data;

    private Slider healthBar1;
    private Slider healthBar2;

    public GameObject heathPrefab1;
    public GameObject heathPrefab2;

    public Gradient healthColor1;
    public Gradient healthColor2;

    private Image fill1;
    private Image fill2;

    float maxhealth = 1000;

    public static float health1 = 1000;
    public static float health2 = 1000;

    public TextMeshProUGUI winnerText;
    public static bool roundOver;

    [Header("Player 1 Icon and Name")]
    public TextMeshProUGUI player1Text;
    public Image player1Icon;
    public List<Image> player1Lives;

    [Header("Player 2 Icon and Name")]
    public TextMeshProUGUI player2Text;
    public Image player2Icon;
    public List<Image> player2Lives;

    private int roundNumber;
    bool onlyOnce = true;

    void Awake()
    {
        player1Controls = PlayerInput.Instantiate(player1, 1, "Controller", -1, GamepadJoin.playerControllers[1]);
        player1Controls.GetComponent<SpriteRenderer>().sprite = CSSManager.player1Fighter;
        var inputUser = player1Controls.user;
        player1Controls.SwitchCurrentControlScheme("Controller");
        InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[1], inputUser, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

        player2Controls = PlayerInput.Instantiate(player2, 2, "Controller", -1, GamepadJoin.playerControllers[2]);
        player2Controls.GetComponent<SpriteRenderer>().sprite = CSSManager.player2Fighter;
        var inputUser2 = player2Controls.user;
        player2Controls.SwitchCurrentControlScheme("Controller");
        InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[2], inputUser2, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

        GameObject bar1 = Instantiate(heathPrefab1, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
        healthBar1 = bar1.GetComponent<Slider>();

        GameObject bar2 = Instantiate(heathPrefab2, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
        healthBar2 = bar2.GetComponent<Slider>();

        fill1 = bar1.GetComponentInChildren<Image>();
        fill2 = bar2.GetComponentInChildren<Image>();
        winnerText.text = "";

        player1Text.text = CSSManager.player1FighterName;
        player2Text.text = CSSManager.player2FighterName;

        player1Icon.sprite = CSSManager.player1Fighter;
        player2Icon.sprite = CSSManager.player2Fighter;

        GameObject.Find("StageBackground").GetComponent<Image>().sprite = CSSManager.stage;

        roundNumber = 1;
        onlyOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Controls.transform.position.x < player2Controls.transform.position.x)
        {
            player1Controls.GetComponent<CharacterMovement>().facingRight = true;
            player2Controls.GetComponent<CharacterMovement>().facingRight = false;
        }
        else
        {
            player1Controls.GetComponent<CharacterMovement>().facingRight = false;
            player2Controls.GetComponent<CharacterMovement>().facingRight = true;
        }
        healthBar1.value = health1;
        healthBar2.value = health2;
        fill1.color = healthColor1.Evaluate(healthBar1.normalizedValue);
        fill2.color = healthColor2.Evaluate(healthBar2.normalizedValue);
        if (roundOver)
        {
            if (health1 <= 0 && health2 > 0)
            {
                winnerText.text = CSSManager.player2FighterName + " Wins!";
                
                //player1Lives[0].enabled = false;
                if (player1Lives.Count == 2)
                {
                    player1Lives[0].enabled = false;
                    player1Lives.RemoveAt(0);
                }
                else if (player1Lives.Count == 1)
                {
                    player1Lives[0].enabled = false;
                    player1Lives.RemoveAt(0);
                }

            }
            else if (health2 <= 0 && health1 > 0)
            {
                winnerText.text = CSSManager.player1FighterName + " Wins!";
                if (player2Lives.Count == 2)
                {
                    player2Lives[0].enabled = false;
                    player2Lives.RemoveAt(0);
                }
                else if (player2Lives.Count == 1)
                {
                    player2Lives[0].enabled = false;
                    player2Lives.RemoveAt(0);
                }
            }
            else
            {
                winnerText.text = "Draw";
            }

            health1 = maxhealth;
            health2 = maxhealth;
            roundOver = false;
            ++roundNumber;

            if (player1Lives.Count == 0 && onlyOnce)
            {
                StartCoroutine(EndGame(CSSManager.player2FighterName));
                onlyOnce = false;
            }
            else if (player2Lives.Count == 0 && onlyOnce)
            {
                StartCoroutine(EndGame(CSSManager.player1FighterName));
                onlyOnce = false;
            }
            else
            {
                StartCoroutine(WaitBetweenRounds());
            }
        }
    }
    IEnumerator WaitBetweenRounds()
    {
        player1Controls.enabled = false;
        player2Controls.enabled = false;
        yield return new WaitForSeconds(5f);
        GameUIManager.newRound = true;
        winnerText.text = "";
        player1Controls.transform.position = player1.transform.position;
        player2Controls.transform.position = player2.transform.position;
        StartCoroutine(DisableControls());
    }
    IEnumerator DisableControls()
    {
        yield return new WaitForSeconds(5f);
        player1Controls.enabled = true;
        player2Controls.enabled = true;
    }
    IEnumerator EndGame(string playerWhoWon)
    {
        player1Controls.enabled = false;
        player2Controls.enabled = false;
        winnerText.text = playerWhoWon + " Is The Binary Camp!";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TitleScreen");
    }
}
