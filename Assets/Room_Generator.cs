using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Generator : MonoBehaviour
{
    // Game object is the wall prefab that has been pre-designed
    public GameObject wall;
    // Vector to store room size
    public Vector2 roomSize = new Vector2(10, 10);

    // Start is called before the first frame update
    void Start()
    {
        // Chnages wall instances angle for the walls created along the z axis
        Quaternion wallAngle = Quaternion.Euler(0, 90, 0);
        // Creates all the wall prefabs along the x axis
        for (int i = 0; i < roomSize.x; i++)
        {
            Instantiate(wall, new Vector3(1 + i, 0, 0), transform.rotation);
            Instantiate(wall, new Vector3(1 + i, 0, roomSize.y + 1), transform.rotation);
        }
        // Creates all the wall prefabs along the z axis
        for (int i = 0; i < roomSize.y; i++)
        {
            Instantiate(wall, new Vector3(0, 0, 1 + i), wallAngle);
            Instantiate(wall, new Vector3(roomSize.x + 1, 0, 1 + i), wallAngle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
