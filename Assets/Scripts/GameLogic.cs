using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI timeText;
    public float timer;
    public string userName;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        userName = StaticData.transferUserName;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<FPSController>().canMove)
        {
            Timer();
        }
    }

    public void Timer()
    {
        timer += Time.deltaTime;
        DisplayTime(timer);
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
