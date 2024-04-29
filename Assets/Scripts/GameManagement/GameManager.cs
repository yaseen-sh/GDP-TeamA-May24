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

    [Header("Fighter Spawn Positions")]
    public Transform player1Pos;
    public Transform player2Pos;

    private PlayerInput player1Controls;
    private PlayerInput player2Controls;

    public CharacterDataLoader Data;

    private Slider healthBar1;
    private Slider healthBar2;

    [Header("Health Bars")]
    public GameObject heathPrefab1;
    public GameObject heathPrefab2;
    public Gradient healthColor1;
    public Gradient healthColor2;
    private Image fill1;
    private Image fill2;

    [Header("Super Bars")]
    public GameObject superPrefab1;
    public GameObject superPrefab2;
    private Slider superBar1;
    private Slider superBar2;
    private Image superFill1;
    private Image superFill2;
    public Gradient superColor;
    public static float super1 = 0;
    public static float super2 = 0;

    const float maxhealth = 3;
    public static float health1 = 3;
    public static float health2 = 3;

    public TextMeshProUGUI winnerText;
    public static bool roundOver;

    [Header("Player 1 Icon and Name")]
    public TextMeshProUGUI player1Text;
    public Image player1Icon;
    public List<Image> player1Lives;
    public static int totalLives1;

    [Header("Player 2 Icon and Name")]
    public TextMeshProUGUI player2Text;
    public Image player2Icon;
    public List<Image> player2Lives;
    public static int totalLives2;

    private int roundNumber;
    bool onlyOnce = true;

    bool super1Filled = false;
    bool super2Filled = false;

    public AudioSource KO;

    public static AudioSource player1Line;
    public static AudioSource player2Line;

    private void Start()
    {
        player1Line = GameObject.Find("CurrentP1VoiceLine").GetComponent<AudioSource>();
        player2Line = GameObject.Find("CurrentP2VoiceLine").GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
    }
    void Awake()
    {
        if (GamepadJoin.playerControllers.ContainsKey(1))
        {
            player1 = CSSManager.player1Object;
            player1Controls = PlayerInput.Instantiate(player1, 1, "Controller", -1, GamepadJoin.playerControllers[1]);
            player1Controls.transform.position = player1Pos.position;
            var inputUser = player1Controls.user;
            player1Controls.SwitchCurrentControlScheme("Controller");
            InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[1], inputUser, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

            player2 = CSSManager.player2Object;
            player2Controls = PlayerInput.Instantiate(player2, 2, "Controller", -1, GamepadJoin.playerControllers[2]);
            player2Controls.transform.position = player2Pos.position;
            var inputUser2 = player2Controls.user;
            player2Controls.SwitchCurrentControlScheme("Controller");
            InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[2], inputUser2, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

            GameObject bar1 = Instantiate(heathPrefab1, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            healthBar1 = bar1.GetComponent<Slider>();

            GameObject bar2 = Instantiate(heathPrefab2, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            healthBar2 = bar2.GetComponent<Slider>();

            fill1 = bar1.GetComponentInChildren<Image>();
            fill2 = bar2.GetComponentInChildren<Image>();

            GameObject sbar1 = Instantiate(superPrefab1, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            superBar1 = sbar1.GetComponent<Slider>();

            GameObject sbar2 = Instantiate(superPrefab2, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            superBar2 = sbar2.GetComponent<Slider>();

            superFill1 = sbar1.GetComponentInChildren<Image>();
            superFill2 = sbar2.GetComponentInChildren<Image>();

            winnerText.text = "";

            player1Text.text = CSSManager.player1FighterName;
            player2Text.text = CSSManager.player2FighterName;

            player1Icon.sprite = CSSManager.player1Fighter;
            player2Icon.sprite = CSSManager.player2Fighter;

            GameObject.Find("StageBackground").GetComponent<Image>().sprite = CSSManager.stage;
            GameObject.Find("BattleMusic").GetComponent<AudioSource>().clip = CSSManager.stageTheme;
            GameObject.Find("BattleMusic").GetComponent<AudioSource>().Play();

            roundNumber = 1;
            onlyOnce = true;

            totalLives1 = player1Lives.Count;
            totalLives2 = player2Lives.Count;

            StartCoroutine(DisableControls(10));
        } 
        else
        {
            Instantiate(player1, player1Pos);
            Instantiate(player2, player2Pos);
            player1Controls = player1.GetComponent<PlayerInput>();
            player2Controls = player2.GetComponent<PlayerInput>();
        }
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
        if (SceneManager.GetActiveScene().name == "BrawlScene")
        {
            healthBar1.value = health1;
            healthBar2.value = health2;
            fill1.color = healthColor1.Evaluate(healthBar1.normalizedValue);
            fill2.color = healthColor2.Evaluate(healthBar2.normalizedValue);

            if (superBar1.value != superBar1.maxValue && !GameUIManager.stopTimer)
            {
                super1 += .5f;
                superBar1.value = super1;
            }
            else
            {
                if (!GameUIManager.stopTimer)
                {
                    superFill1.color = superColor.Evaluate(Time.deltaTime);
                    //super1Filled = true;
                }
            }

            if (superBar2.value != superBar2.maxValue && !GameUIManager.stopTimer)
            {
                super2 += .5f;
                superBar2.value = super2;
            }
            else
            {
                if (!GameUIManager.stopTimer)
                {
                    superFill2.color = superColor.Evaluate(Time.deltaTime);
                // super2Filled = true;
                }
            }

            if (roundOver)
            {
                if (health1 < health2)
                {
                    winnerText.color = new Color(1f, 0, 0, 1f);
                    winnerText.text = CSSManager.player2FighterName + " Wins!";

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
                    totalLives1 = player1Lives.Count;
                    totalLives2 = player2Lives.Count;
                }
                else if (health2 < health1)
                {
                    winnerText.color = new Color(0, 0, 1f, 1f);
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
                    totalLives1 = player1Lives.Count;
                    totalLives2 = player2Lives.Count;
                }
                else
                {
                    winnerText.color = new Color(1f, 0, 1f, 1f);
                    winnerText.text = "Both Lose";
                    player1Lives[0].enabled = false;
                    player1Lives.RemoveAt(0);
                    player2Lives[0].enabled = false;
                    player2Lives.RemoveAt(0);
                    totalLives1 = player1Lives.Count;
                    totalLives2 = player2Lives.Count;
                }

                health1 = maxhealth;
                health2 = maxhealth;
                roundOver = false;
                ++roundNumber;

                if (player1Lives.Count == 0 && player2Lives.Count == 0)
                {
                    super1 = 0;
                    super2 = 0;
                    superBar1.value = 0;
                    superBar2.value = 0;
                    StartCoroutine(EndGame("Nobody"));
                    onlyOnce = false;
                }
                if (player1Lives.Count == 0 && onlyOnce)
                {
                    if (GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines.ContainsKey("lose3"))
                    {
                        int randNum = Random.Range(1, 4);
                        player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["lose" + randNum.ToString()];
                    }
                    else if (GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines.ContainsKey("lose2"))
                    {
                        int randNum = Random.Range(1, 3);
                        player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["lose" + randNum.ToString()];
                    }
                    else
                    {
                        player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["lose1"]; //whatever lose line is
                    }

                    if (GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines.ContainsKey("victory2"))
                    {
                        int randNum = Random.Range(1, 3);
                        player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["victory" + randNum.ToString()];
                    }
                    else
                    {
                        player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["victory1"]; //whatever win line is
                    }

                    super1 = 0;
                    super2 = 0;
                    superBar1.value = 0;
                    superBar2.value = 0;
                    StartCoroutine(EndGame(CSSManager.player2FighterName));
                    onlyOnce = false;
                }
                else if (player2Lives.Count == 0 && onlyOnce)
                {
                    if (GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines.ContainsKey("lose3"))
                    {
                        int randNum = Random.Range(1, 4);
                        player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["lose" + randNum.ToString()];
                    }
                    else if (GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines.ContainsKey("lose2"))
                    {
                        int randNum = Random.Range(1, 3);
                        player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["lose" + randNum.ToString()];
                    }
                    else
                    {
                        player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["lose1"]; //whatever lose line is
                    }

                    if (GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines.ContainsKey("victory2"))
                    {
                        int randNum = Random.Range(1, 3);
                        player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["victory" + randNum.ToString()];
                    }
                    else
                    {
                        player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["victory1"]; //whatever win line is
                    }

                    super1 = 0;
                    super2 = 0;
                    superBar1.value = 0;
                    superBar2.value = 0;
                    StartCoroutine(EndGame(CSSManager.player1FighterName));
                    onlyOnce = false;
                }
                else
                {
                    StartCoroutine(WaitBetweenRounds());
                }
            }
        }
    }
    IEnumerator WaitBetweenRounds()
    {
        player1Controls.DeactivateInput();
        player2Controls.DeactivateInput();
        GameUIManager.stopTimer = true;
        yield return new WaitForSeconds(7f);
        GameUIManager.newRound = true;
        winnerText.text = "";
        player1Controls.transform.position = player1Pos.position;
        player2Controls.transform.position = player2Pos.position;
        player1Controls.ActivateInput();
        player2Controls.ActivateInput();
    }
    IEnumerator DisableControls(float num)
    {
        player1Controls.DeactivateInput();
        player2Controls.DeactivateInput();
        yield return new WaitForSeconds(num);
        player1Controls.ActivateInput();
        player2Controls.ActivateInput();
    }
    IEnumerator EndGame(string playerWhoWon)
    {
        KO.Play();
        player1Controls.enabled = false;
        player2Controls.enabled = false;
        GameUIManager.stopTimer = true;
        player1Controls.DeactivateInput();
        player2Controls.DeactivateInput();
        yield return new WaitForSeconds(2f);
        winnerText.color = new Color(1f, 0, 1f, 1f);
        winnerText.text = playerWhoWon + " Is The Binary Champ!";

        // Play the winner's Victory Line & the Looser's lost line!
        if (playerWhoWon == CSSManager.player1FighterName)
        {
            player1Line.Play();
            yield return new WaitForSeconds(3f);
            player2Line.Play();
        }
        else if (playerWhoWon == CSSManager.player2FighterName)
        {
            player2Line.Play();
            yield return new WaitForSeconds(3f);
            player1Line.Play();
        }

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("TitleScreen");
    }
}
