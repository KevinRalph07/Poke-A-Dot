using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    // class variables
    public GameObject myGameObject;
    public Sprite[] dotSprite;
    public DotColors myColor;
    public int myIndex;
    public bool isPoked;

    private void Awake()
    {
        // set initial color to random color
        myColor = (DotColors)(int)Random.Range(1, Globals.DotColorsLength);
        // set poked to false
        isPoked = false;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        // update dot color
        switch(myColor)
        {
            case DotColors.GREEN:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[0];
                break;
            case DotColors.BLUE:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[1];
                break;
            case DotColors.RED:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[2];
                break;
            case DotColors.YELLOW:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[3];
                break;
            case DotColors.CYAN:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[4];
                break;
            case DotColors.PURPLE:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[5];
                break;
            case DotColors.ORANGE:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[6];
                break;
            case DotColors.PINK:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[7];
                break;
            case DotColors.MAROON:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[8];
                break;
            case DotColors.NAVY:
                myGameObject.GetComponent<SpriteRenderer>().sprite = dotSprite[9];
                break;
            default:
                print("INVALID COLOR");
                break;
        }
    }

    private void OnMouseDown()
    {
        // register poke
        isPoked = true;
    }
}
