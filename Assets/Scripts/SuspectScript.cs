using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuspectScript : MonoBehaviour
{
    // Links to the text box on the game screen to display the character lines
    public TextMeshProUGUI suspectText;

    // The suspect and the room that the charcter will confirm that are innocent
    public string speekSuspect;
    public string speekRoom;

    // The message that the character will say
    string message;

    // Start is called before the first frame update
    void Start()
    { // The message that a character will say
        message = gameObject.name.Split("(")[0] + ": I saw " + speekSuspect + " in the " + speekRoom;
    }

    // Triggered by the OnTriggerEnter event
    public void CharacterLines()
    {
        // Displays the message in the txt box on screen
        suspectText.text = message;
    }

    // Triggered by the OnTriggerExit event
    public void RemoveCharacterLines()
    {
        // Sets the text box to nothing 
        suspectText.text = "";
    }

    // Once the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Make the charcter say something
        CharacterLines();
    }

    // Once the player leaves the trigger collider
    private void OnTriggerExit(Collider other)
    {
        // Hide what the caharcter is saying
        RemoveCharacterLines();
    }
}
