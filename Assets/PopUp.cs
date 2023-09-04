using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        popup.SetActive(false);
    }

    public void Hide()
    {
        popup.SetActive(false);
    }

    public void Show()
    {
        popup.SetActive(true);
    }
}
