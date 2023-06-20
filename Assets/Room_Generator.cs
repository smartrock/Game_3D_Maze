using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Generator : MonoBehaviour
{
    // Game object is the wall prefab that has been pre-designed
    public GameObject wall;

    // Can chose max room size
    public float maxWidth = 10;
    public float maxLength = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Chnages wall instances angle for the walls created along the z axis
        Quaternion wallAngle = Quaternion.Euler(0, 90, 0);

        // Randomly chooses room size
        int wallWdith = Random.Range(5, (int)maxWidth);
        int wallLength = Random.Range(5, (int)maxLength);

        // Creates all the wall prefabs along the x axis
        for (int i = 0; i < wallWdith; i++)
        {
            Instantiate(wall, new Vector3(1 + i, 0, 0), transform.rotation);
            Instantiate(wall, new Vector3(1 + i, 0, wallLength + 1), transform.rotation);
        }
        // Creates all the wall prefabs along the z axis
        for (int i = 0; i < wallLength; i++)
        {
            Instantiate(wall, new Vector3(0, 0, 1 + i), wallAngle);
            Instantiate(wall, new Vector3(wallWdith + 1, 0, 1 + i), wallAngle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
