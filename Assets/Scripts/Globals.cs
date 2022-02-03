using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enums
public enum DotColors { GREEN, BLUE, RED, YELLOW, CYAN, PURPLE, ORANGE, PINK, MAROON, NAVY, END };
public enum Modes { EASY, MEDIUM, HARD, MINUTE, MENU };

public class Globals : MonoBehaviour
{
    // globals
    public static float DotColorsLength = (float)DotColors.END;

    void Awake()
    {

    }

}
