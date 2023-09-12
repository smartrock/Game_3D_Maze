using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startMenu;
    public TMP_InputField inputField;
   
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        inputField.Select();
        inputField.text = "";
    }

    public void ChangeMenu()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void UserName()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
