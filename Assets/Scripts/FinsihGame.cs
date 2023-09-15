using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinsihGame : MonoBehaviour
{
    // Gameobjects to reference in the scripts
    public GameObject GameManager;

    // Links in the sumbmit screen so that it can be turned on and off
    public GameObject submitScreen;

    // SHows if the submit screen is active. This is used in the player controller script to allow the cursor to show
    public bool submitActive;

    // Start is called before the first frame update
    void Start()
    {
        // Calls the hide function
        SubmitScreenHide();
    }

    // Update is called once a frame
    private void Update()
    {
        // Checks if the game is finished, then it will call the hide on the game screen
        if (GameManager.GetComponent<CheckResult>().gameFinished)
        {
            // Calls the hide function
            SubmitScreenHide();
        }
    }

    // When the player enters the trigger box collider
    private void OnTriggerEnter(Collider other)
    {
        // Call the screen show function
        SubmitScreenShow();
    }

    // When the player leaves the trigger box collider
    private void OnTriggerExit(Collider other)
    {
        // Hide the screen so the player can't interact with it
        SubmitScreenHide();
    }

    public void SubmitScreenShow()
    {
        // Shows submit screen
        submitScreen.SetActive(true);
        // Sets the screen active bool to true so that the cursor will appear so that the player can actually interact with the screen
        submitActive = true;
    }

    // Screen hide function
    public void SubmitScreenHide()
    {
        // Hides submit screen
        submitScreen.SetActive(false);
        // Set the screen active bool to false so the cursor will disappear again
        submitActive = false;
    }
}
