using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class StartMenuManager : MonoBehaviour
{
    // The two menus so that they can be activated and deactivated
    public GameObject mainMenu;
    public GameObject startMenu;
    // This is a space for the players username
    public TMP_InputField inputField;
    // This is where the leader board can be displayed
    public TextMeshProUGUI leaderboard;

    // A list to store the leaderboard text file lines each as one string
    public List<string> leaderboardValues = new List<string>();

    // Checks if the username input is full or not
    public bool inputFieldFull;
   
    // Start is called before the first frame update
    void Start()
    {
        // Sets the opening page to visible and the main menu to invisible
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        inputFieldFull = false;
        // Set the username input to empty
        inputField.text = "";
        // Set the leaderboard to the high scores gathered from a text file
        leaderboard.text = "";
        // Empties the list to leaderboard string values
        leaderboardValues.Clear();
        // Adds the text file values into a list
        leaderboardValues = File.ReadAllLines(Application.streamingAssetsPath + "/highscores.txt").ToList();

        // Changes the list of strings into one single string
        foreach (string item in leaderboardValues)
        {
            // Puts each new list item onto a new line to spread out the strings
            leaderboard.text += item + Environment.NewLine;
        }
    }

    // This is called whan the play button is pressed
    public void ChangeMenu()
    {
        // Switches between the start menu and the main menu
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    // Update is called once a frame update
    private void Update()
    {
        // If the username box is not empty then allow the game to start
        if (inputField.text != "")
        {
            inputFieldFull = true;
        }
    }

    // This is called when the start button is pressed
    public void StartGame()
    {
        // If the input contains some character
        if (inputFieldFull)
        {
            // creates a string of the username entered
            string userName = inputField.text;
            // Creates a string of the leaderboard text
            string currentLeaderboard = leaderboard.text;
            // Sets global variables for the username and leaderboard to move them between scenes
            PlayerName.playerName = userName;
            PlayerName.currentLeaderboard = currentLeaderboard;
            // Changes the scene to the game scene
            SceneManager.LoadScene(1);
        }
    }

    // WHen the quit button is pressed stop the game
    public void Quit()
    {
        Application.Quit();
    }
}
