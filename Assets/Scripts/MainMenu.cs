using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    // The pause menu so that it can be activated and deactivated
    public GameObject pauseMenu;
    // Changes the pause bool which will be taken by the player script so it can enable and diable the player movement
    public bool pauseMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        // Set the pause menu active to false
        pauseMenuActive = false;
        // Hides the pause menu
        pauseMenu.SetActive(pauseMenuActive);
    }

    // Update is called once per frame
    void Update()
    {
        // Activates pause menu either with escape or p being pressed
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
        {
            PauseMenu();
        }
    }

    // When the pause menu is either activated or deactivated
    public void PauseMenu()
    {
        // Sets the pause active bool to the opposite state
        pauseMenuActive = !pauseMenuActive;
        // Sets the UI to the new bool state making it either show or hide
        pauseMenu.SetActive(pauseMenuActive);
    }

    // When the exit button on screen is pressed switch back the the start scene
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
