using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dot_Manager : MonoBehaviour
{
    // class variables
    public List<Dot> Dots;

    public int oldDot;
    public int newDot;
    public int pokedDot;

    public float countdown;
    public float timer;
    public float easyTime;
    public float mediumTime;
    public float hardTime;
    public float minuteTime;
    public float selectedTime;
    public float hintTimer;
    public float hintTime;

    public int score;

    public TextMeshProUGUI uiScore;
    public TextMeshProUGUI uiCountdown;

    public GameObject uiGameOver;
    public GameObject uiTimer;
    public GameObject hintHighlight;

    public bool isPlaying;
    public bool isCountdown;

    private void Awake()
    {
        // create list of Dot objects
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Dots.Add(this.transform.GetChild(i).GetComponent<Dot>());
            this.transform.GetChild(i).GetComponent<Dot>().myIndex = i;
        }
        pokedDot = -1;
    }

    void Start()
    {
        // disable controls and start countdown
        isPlaying = false;
        isCountdown = true;

        // set first dot green
        Dots[0].myColor = DotColors.GREEN;

        // set initial values
        newDot = 0;
        oldDot = 0;
        countdown = 6.0f;
        score = 0;

        // difficulty times
        easyTime = 2.0f;
        mediumTime = 1.0f;
        hardTime = 0.5f;
        minuteTime = 60.0f;
        hintTime = 5.0f;

        // set timer
        switch (PlayerPreferences.currentMode)
        {
            case Modes.EASY:
                selectedTime = easyTime;
                break;
            case Modes.MEDIUM:
                selectedTime = mediumTime;
                break;
            case Modes.HARD:
                selectedTime = hardTime;
                break;
            case Modes.MINUTE:
                selectedTime = minuteTime;
                break;
            default:
                print("INVALID MODE");
                break;
        }
        timer = selectedTime;
        hintTimer = hintTime;

        // disable game over screen
        uiGameOver.SetActive(false);
        // disable hint highlight
        hintHighlight.SetActive(false);
    }

    void Update()
    {
        // starting countdown
        if (isCountdown)
        {
            uiCountdown.text = "" + (int)countdown;
            countdown -= Time.deltaTime;
            // end countdown and start game
            if (countdown <= 1)
            {
                foreach (Dot d in Dots)
                {
                    d.isPoked = false;
                }
                isCountdown = false;
                isPlaying = true;
                uiCountdown.enabled = false;
                // assign random colors
                for (int i = 0; i < Dots.Count; i++)
                {
                    Dots[i].myColor = (DotColors)(int)Random.Range(1, Globals.DotColorsLength);
                }
                // set new dot
                oldDot = newDot;
                while (newDot == oldDot)
                    newDot = (int)Random.Range(0, Dots.Count);
                Dots[newDot].myColor = DotColors.GREEN;
                //Poke(0);
                //Dots[0].isPoked = true;
                //score = 0;
            }
        }

        // timer update and check
        if (isPlaying)
        {
            timer -= Time.deltaTime;
            uiTimer.GetComponent<Image>().fillAmount = timer / selectedTime;
            if (timer <= 0)
            {
                GameOver(PlayerPreferences.currentMode);
                print("OUTTA TIME");
            }

            if (PlayerPreferences.currentMode == Modes.MINUTE)
            {
                hintTimer -= Time.deltaTime;
                if (hintTimer <= 0)
                {
                    hintHighlight.transform.position = new Vector3(Dots[oldDot].transform.position.x, Dots[oldDot].transform.position.y, hintHighlight.transform.position.z); ;
                    hintHighlight.SetActive(true);
                }
            }

            CheckPokes();
        }

        // print score
        uiScore.text = "" + score;
    }

    public void CheckPokes()
    {
        // find poked dot
        foreach(Dot d in Dots)
        {
            if(d.isPoked)
            {
                pokedDot = d.myIndex;
                d.isPoked = false;
                break;
            }
        }
        // no dot was poked
        if (pokedDot == -1)
            return;
        // gameloop is being played
        if (isPlaying)
        {
            // check if right dot
            if (pokedDot == oldDot)
            {
                // assign random colors
                for (int i = 0; i < Dots.Count; i++)
                {
                    Dots[i].myColor = (DotColors)(int)Random.Range(1, Globals.DotColorsLength);
                }
                // set new dot
                oldDot = newDot;
                while (newDot == oldDot)
                    newDot = (int)Random.Range(0, Dots.Count);
                Dots[newDot].myColor = DotColors.GREEN;
                // increment score
                score++;
                // reset time for speed mode
                if (PlayerPreferences.currentMode != Modes.MINUTE)
                {
                    timer = selectedTime;
                }
                hintTimer = hintTime;
                hintHighlight.SetActive(false);
                
            }

            // if wrong dot
            else
            {
                // decrement score for minute mode
                if (PlayerPreferences.currentMode == Modes.MINUTE)
                {
                    score -= 2;
                    hintTimer -= 1;
                }
                // game over for speed mode
                else
                {
                    GameOver(PlayerPreferences.currentMode);
                    print("WRONG DOT");
                }
            }
        }
        // reset pokedDot
        pokedDot = -1;
    }

    public void GameOver(Modes mode)
    {
        // update highscore
        switch (mode)
        {
            case Modes.EASY:
                PlayerPreferences.easy_highscore = Mathf.Max(score, PlayerPreferences.easy_highscore);
                break;
            case Modes.MEDIUM:
                PlayerPreferences.medium_highscore = Mathf.Max(score, PlayerPreferences.medium_highscore);
                break;
            case Modes.HARD:
                PlayerPreferences.hard_highscore = Mathf.Max(score, PlayerPreferences.hard_highscore);
                break;
            case Modes.MINUTE:
                PlayerPreferences.minute_highscore = Mathf.Max(score, PlayerPreferences.minute_highscore);
                break;
            default:
                print("INVALID MODE");
                break;
        }
        PlayerPreferences.SaveHighscores();

        // disable controls
        isPlaying = false;

        // enable game over screen
        uiGameOver.SetActive(true);
    }
}
