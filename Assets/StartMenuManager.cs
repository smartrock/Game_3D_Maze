using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startMenu;
   
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    public void ChangeMenu()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
