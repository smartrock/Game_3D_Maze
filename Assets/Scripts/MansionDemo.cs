using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MansionDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mansion m = MansionGenerator.Generate();
        Debug.Log(m.ToString());
    }
}
