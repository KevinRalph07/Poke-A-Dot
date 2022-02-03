using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject minuteButton;
    public GameObject highlight;

    private void Awake()
    {
        OptionsMenu.SetActive(false);
    }

    void Start()
    {
        //easyButton.GetComponent<Button>().onClick.Invoke();
        //easyButton.GetComponent<Button>().Select();
        switch (PlayerPreferences.currentMode)
        {
            case Modes.EASY:
                highlight.transform.position = easyButton.transform.position;
                break;
            case Modes.MEDIUM:
                highlight.transform.position = mediumButton.transform.position;
                break;
            case Modes.HARD:
                highlight.transform.position = hardButton.transform.position;
                break;
            case Modes.MINUTE:
                highlight.transform.position = minuteButton.transform.position;
                break;
            default:
                print("INVALID MODE");
                break;
        }
    }

    public void ModeChange(int mode)
    {
        PlayerPreferences.currentMode = (Modes)mode;
        PlayerPreferences.SaveMode();
        switch (PlayerPreferences.currentMode)
        {
            case Modes.EASY:
                highlight.transform.position = easyButton.transform.position;
                break;
            case Modes.MEDIUM:
                highlight.transform.position = mediumButton.transform.position;
                break;
            case Modes.HARD:
                highlight.transform .position = hardButton.transform.position;
                break;
            case Modes.MINUTE:
                highlight.transform.position = minuteButton.transform.position;
                break;
            default:
                print("INVALID MODE");
                break;
        }
    }

    public void Enter()
    {
        OptionsMenu.SetActive(true);
    }

    public void Exit()
    {
        OptionsMenu.SetActive(false);
    }
}
