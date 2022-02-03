using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscores : MonoBehaviour
{
    public TextMeshProUGUI uiHighscore;

    void Update()
    {
        switch (PlayerPreferences.currentMode)
        {
            case Modes.EASY:
                uiHighscore.text = "BEST: " + PlayerPreferences.easy_highscore;
                break;
            case Modes.MEDIUM:
                uiHighscore.text = "BEST: " + PlayerPreferences.medium_highscore;
                break;
            case Modes.HARD:
                uiHighscore.text = "BEST: " + PlayerPreferences.hard_highscore;
                break;
            case Modes.MINUTE:
                uiHighscore.text = "BEST: " + PlayerPreferences.minute_highscore;
                break;
            default:
                print("INVALID MODE");
                break;
        }
    }
}
