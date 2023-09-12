using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pauseMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuActive = false;
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

    public void PauseMenu()
    {
        // Sets the pause active bool to the opposite state
        pauseMenuActive = !pauseMenuActive;
        // Sets the UI to the new bool state making it either show or hide
        pauseMenu.SetActive(pauseMenuActive);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
