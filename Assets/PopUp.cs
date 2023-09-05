using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject popup;
    public bool popupActive;

    void Start()
    {
        popup.SetActive(false);
        popupActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            popupActive = !popupActive;
            popup.SetActive(popupActive);
        }
    }
}
