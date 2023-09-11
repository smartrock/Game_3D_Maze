using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Button_Color : MonoBehaviour
{
    public GameObject button;
    Color white = Color.white;
    Color red = Color.red;
    Color green = Color.green;

    public void ChangeButtonColour(Image button)
    {
        if (button.color == white)
        {
            button.color = red;
        }
        else if (button.color == red)
        {
            button.color = green;
        }
        else {
            button.color = white;
        }
    }
}
