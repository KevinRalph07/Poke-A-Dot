using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu_Dot_Manager : MonoBehaviour
{
    public TextMeshProUGUI playButtonText;

    // class variables
    public List<Dot> Dots;
    public float timer;
    public float delay;
    public int oldDot;
    public int newDot;

    private void Awake()
    {
        // create list of Dot objects
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Dots.Add(this.transform.GetChild(i).GetComponent<Dot>());
            this.transform.GetChild(i).GetComponent<Dot>().myIndex = i;
        }
    }

    void Start()
    {
        // set first dot green
        Dots[0].myColor = DotColors.GREEN;
        oldDot = 0;
        newDot = 0;
        delay = 1.0f;
        timer = delay;
        //print(PlayerPreferences.currentMode.ToString());
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // change dots
            // assign random colors
            for (int i = 0; i < Dots.Count; i++)
            {
                Dots[i].myColor = (DotColors)(int)Random.Range(1, Globals.DotColorsLength);
            }
            oldDot = newDot;
            // choose new dot
            while (newDot == oldDot)
                newDot = (int)Random.Range(0, Dots.Count);
            // set new dot to green
            Dots[newDot].myColor = DotColors.GREEN;

            // reset timer
            timer = delay;
        }
        //PlayerPreferences.currentMode = Modes.ENDURANCE;
        playButtonText.text = "PLAY\n" + PlayerPreferences.currentMode.ToString() + " MODE";
    }
}
