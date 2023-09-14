using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Get pop up so that it can be shown and hiden
    public GameObject popup;
    // Tells whether the pop up is active. This allow the cursor to show so that it can be used
    public bool popupActive;

    void Start()
    {
        // Initially hide the pop up and set the pop up bool to false to lock the cursor
        popup.SetActive(false);
        popupActive = false;
    }

    private void Update()
    {
        // When the tab key is pressed
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            // If the pop up is active, hide it. If the pop up is hidden, activate it
            popupActive = !popupActive;
            popup.SetActive(popupActive);
        }
    }
}
