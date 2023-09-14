using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinsihGame : MonoBehaviour
{
    // Gameobjects to reference in the scripts
    public GameObject GameManager;
    public GameObject submitScreen;
    public bool submitActive;

    // Start is called before the first frame update
    void Start()
    {
        // Calls the hide function
        SubmitScreenHide();
    }

    private void Update()
    {
        if (GameManager.GetComponent<CheckResult>().gameFinished)
        {
            SubmitScreenHide();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SubmitScreenShow();
    }

    private void OnTriggerExit(Collider other)
    {
        SubmitScreenHide();
    }

    public void SubmitScreenShow()
    {
        // Shows submit screen
        submitScreen.SetActive(true);
        submitActive = true;
    }

    public void SubmitScreenHide()
    {
        // Hides submit screen
        submitScreen.SetActive(false);
        submitActive = false;
    }
}
