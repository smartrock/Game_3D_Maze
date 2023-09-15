using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Color : MonoBehaviour
{
    // Space for a bitton game object to be added
    public GameObject button;

    // The preset colours for the buttons to change to
    Color white = Color.white;
    Color red = Color.red;
    Color green = Color.green;

    // Reference when a button on the pop up menu is clicked
    public void ChangeButtonColour(Image button)
    {
        // If the button is currently white then change it to read
        if (button.color == white)
        {
            button.color = red;
        }
        else if (button.color == red)
        {
            // If the button is red chnage it to green
            button.color = green;
        }
        else {
            // If the button is green change it to white
            button.color = white;
        }
    }
}
