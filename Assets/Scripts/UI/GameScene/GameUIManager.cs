using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI roundNumberText;
    public TextMeshProUGUI brawlText;

    public TextMeshProUGUI timerText;
    public int timer = 99;

    private int roundNumber;

    private string round = "ROUND";
    //private string fighttext = "fighttext";
    public static bool newRound = false;
    public static bool stopTimer = false;

    public TextMeshProUGUI fighter1IntroText;
    public TextMeshProUGUI fighter2IntroText;
    public TextMeshProUGUI vs;

    public AudioSource anouncer1;
    public AudioSource anouncer2;
    public AudioSource readyFightLine;

    void Start()
    {
        fighter1IntroText.text = "";
        fighter2IntroText.text = "";
        vs.text = "";
        roundText.text = "";
        roundNumberText.text = "";
        brawlText.text = "";
        roundNumber = 1;
        timerText.text = "99";
        timer = 99;
        stopTimer = true;
        anouncer1.clip = CSSManager.player1Intro;
        anouncer2.clip = CSSManager.player2Intro;
        StartCoroutine(FightIntro());
        StartCoroutine(timerCountDown(12));
    }
    void Update()
    {
        if (newRound)
        {
            timer = 99;
            StopAllCoroutines();
            StartCoroutine(showRoundText());
            StartCoroutine(timerCountDown(3));
            roundNumber++;
            newRound = false;
        }
    }
    public IEnumerator showRoundText()
    {
        readyFightLine.Play();
        foreach(char letter in round.ToCharArray())
        {
            roundText.text += letter;
            yield return new WaitForSeconds(0.15f);
        }
        if (roundNumber == 1)
            roundNumberText.text = "01";
        else if (roundNumber == 2)
            roundNumberText.text = "10";
        else if (roundNumber == 3)
            roundNumberText.text = "11";

        roundNumberText.GetComponent<Animator>().Play("FightStart");
        roundNumberText.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        brawlText.text = "FIGHT";
        brawlText.GetComponent<Animator>().Play("fighttext");
        brawlText.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(1f);
        roundNumberText.text = "";
        brawlText.text = "";
        roundText.text = "";
        brawlText.GetComponent<Animator>().enabled = false;
        roundNumberText.GetComponent<Animator>().enabled = false;
    }

    IEnumerator timerCountDown(float wait)
    {
        yield return new WaitForSeconds(wait);
        stopTimer = false;
        while (timer > -1)
        {
            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1);
            --timer;
            if (stopTimer)
            {
                Debug.Log("New Round");
                yield break;
            }
        }
        if (timer <= -1)
        {
            GameManager.roundOver = true;
        }
    }
    IEnumerator FightIntro()
    {
        anouncer1.Play();
        fighter1IntroText.text = CSSManager.player1FighterName;
        yield return new WaitForSeconds(1f);
        vs.text = "VS";
        yield return new WaitForSeconds(1f);
        anouncer2.Play();
        fighter2IntroText.text = CSSManager.player2FighterName;
        yield return new WaitForSeconds(2f);
        fighter1IntroText.text = "";
        fighter2IntroText.text = "";
        vs.text = "";
        // Play the intro voicelines from each character 
        int rand1 = Random.Range(1, 3);
        if (GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines.ContainsKey("roundstart" + rand1.ToString())) 
        {
            GameManager.player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["roundstart" + rand1.ToString()];
        }
        else
        {
            GameManager.player1Line.clip = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Hitbox>().voiceLines["roundstart1"];
        }
        GameManager.player1Line.Play();
        yield return new WaitForSeconds(3f);
        int rand2 = Random.Range(1, 3);
        if (GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines.ContainsKey("roundstart" + rand2.ToString()))
        {
            GameManager.player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["roundstart" + rand2.ToString()];
        }
        else
        {
            GameManager.player2Line.clip = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Hitbox>().voiceLines["roundstart1"];
        }
        GameManager.player2Line.Play();
        yield return new WaitForSeconds(3f);
        StartCoroutine(showRoundText());
    }
}
