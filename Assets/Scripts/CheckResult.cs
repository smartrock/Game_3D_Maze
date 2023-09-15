using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CheckResult : MonoBehaviour
{
    // The game objects on the final finish screen to change from deactive to active
    public GameObject finishScreen;
    public GameObject congratsMessage;
    public GameObject failureMessage;

    // The game manager so that can reference other scripts
    public GameObject GameManager;

    // The text file that saves the highscores and usernames
    public TextAsset textFile;

    // Text boxes that display the players answer, actual answer, and the time the player toook
    public TextMeshProUGUI playerResultText;
    public TextMeshProUGUI gameResultText;
    public TextMeshProUGUI playerTimeTookText;

    // Dropdown boxes on the check zone for the player to input their answer
    public TMP_Dropdown suspectButton;
    public TMP_Dropdown weaponButton;
    public TMP_Dropdown roomButton;

    // Strings to display the anserws that the player selected
    public string suspectSelected;
    public string weaponSelected;
    public string roomSelected;

    // Strings to store the actual game answers
    string chosenSuspect;
    string chosenWeapon;
    string chosenRoom;

    // Bool to stop game
    public bool gameFinished;
    // Bool to detrimine if the player completed the game
    public bool wonGame;

    // Start is called before the first frame update
    void Start()
    {
        // Sets end of game bools to false since game isn't over
        gameFinished = false;
        wonGame = false;
        // Hide the finish screen and the congrats and failure messages
        finishScreen.SetActive(gameFinished);
        congratsMessage.SetActive(gameFinished);
        failureMessage.SetActive(gameFinished);
        // Sets all these strings to nothing to clear any previous values
        suspectSelected = string.Empty;
        weaponSelected = string.Empty;
        roomSelected = string.Empty;
        playerResultText.text = string.Empty;
        gameResultText.text = string.Empty;

        // Gets the game answers and sets them to their string equiviliants
        chosenSuspect = GameManager.GetComponent<Game_Generation>().chosenSuspect.name;
        chosenWeapon = GameManager.GetComponent<Game_Generation>().chosenWeapon.name;
        chosenRoom = GameManager.GetComponent<Game_Generation>().chosenRoom;
    }

    // If the check / submit button on the check zone screen is pressed then this function will run
    public void CheckResultGame()
    {
        // Bool stops other game functions and shows the finished screen
        gameFinished = true;
        finishScreen.SetActive(gameFinished);
        // Converts the dropdown boxes to their string equiviliants
        suspectSelected = suspectButton.options[suspectButton.value].text;
        weaponSelected = weaponButton.options[weaponButton.value].text;
        roomSelected = roomButton.options[roomButton.value].text;
        // Displays the players answer in a proper sentence
        playerResultText.text = suspectSelected + " with the " + weaponSelected + " in the " + roomSelected;

        // If the player submitted result is correct
        if (suspectSelected == chosenSuspect && weaponSelected == chosenWeapon && roomSelected == chosenRoom)
        {
            // Display the congrats message
            congratsMessage.SetActive(true);
            // Set the won game to true so that the exit button will write to the text file
            wonGame = true;
            // Display the players time in text box down the bottom
            playerTimeTookText.text = "Your time was " + GameManager.GetComponent<GameLogic>().timeFormatted;
        }
        else
        {
            // If the player was wrong then show the failure message instead
            failureMessage.SetActive(true);
            // Show what the murder, weapon, and room actually was
            gameResultText.text = "It was actually " + chosenSuspect + " with the " + chosenWeapon + " in the " + chosenRoom;
        }
    }

    // Triggered by the button on the finish screen
    public void WriteToFile()
    {
        // Only if the player was correct will the time be saved
        if (wonGame)
        {
            // Sets the string to be added to the text file to the current string + the player username + the time it took
            string writeToFile = PlayerName.currentLeaderboard + Environment.NewLine + "Username: " + PlayerName.playerName + "     Time: " + GameManager.GetComponent<GameLogic>().timeFormatted;
            // Writes the text file with the string created
            File.WriteAllText(Application.streamingAssetsPath + "/highscores.txt", writeToFile);
            //EditorUtility.SetDirty(textFile);
        }
    }
}
