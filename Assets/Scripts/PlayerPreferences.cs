using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    // class variables
    public static int easy_highscore;
    public static int medium_highscore;
    public static int hard_highscore;
    public static int minute_highscore;
    public static Modes currentMode;

    void Awake()
    {
        easy_highscore = PlayerPrefs.GetInt("easy highscore");
        medium_highscore = PlayerPrefs.GetInt("medium highscore");
        hard_highscore = PlayerPrefs.GetInt("hard highscore");
        minute_highscore = PlayerPrefs.GetInt("minute highscore");
        currentMode = (Modes)PlayerPrefs.GetInt("current mode");
    }

    private void OnApplicationQuit()
    {
        SaveHighscores();
    }

    private void ResetHighscores()
    {
        PlayerPrefs.SetInt("easy highscore", 0);
        PlayerPrefs.SetInt("medium highscore", 0);
        PlayerPrefs.SetInt("hard highscore", 0);
        PlayerPrefs.SetInt("minute highscore", 0);
        PlayerPrefs.Save();
    }

    public static void SaveHighscores()
    {
        PlayerPrefs.SetInt("easy highscore", easy_highscore);
        PlayerPrefs.SetInt("medium highscore", medium_highscore);
        PlayerPrefs.SetInt("hard highscore", hard_highscore);
        PlayerPrefs.SetInt("minute highscore", minute_highscore);
        PlayerPrefs.Save();
    }

    public static void SaveMode()
    {
        PlayerPrefs.SetInt("current mode", (int)currentMode);
        PlayerPrefs.Save();
    }
}
