using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Links in the player so the movement script attatched to the player can be accessed
    public GameObject player;

    // A text box to show the time as the player is playing
    public TextMeshProUGUI timeText;
    
    // A float for the time taken to be stored as
    public float timer;

    // A string to store the minutes, seconds format of the time
    public string timeFormatted;

    // Start is called before the first frame update
    void Start()
    {
        // Ste the time to 0
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is able to move around then call the timer
        if (player.GetComponent<FPSController>().canMove)
        {
            Timer();
        }
    }

    // If the timer is called
    public void Timer()
    {
        // Add the time of a frame to the previous frame time
        timer += Time.deltaTime;
        // Call the display time function with the current time
        DisplayTime(timer);
    }

    // When this function is called with the current time
    public void DisplayTime(float timeToDisplay)
    {
        // Calculate the minute version of the time
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        // Calculate the seconds version of the time
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // Sets the format to minutes and the seconds
        timeFormatted = string.Format("{0:00}:{1:00}", minutes, seconds);
        // Sets the text box to the formatted time string
        timeText.text = timeFormatted;
    }
}
