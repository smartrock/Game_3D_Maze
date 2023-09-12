using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MansionRenderer : MonoBehaviour
{
    public Transform[] floorPrefab;
    public Transform[] wallPrefab;
    public Transform[] roofPrefab;
    Transform mnsnFolder;

    public void Render(Mansion bldg)
    {
        mnsnFolder = new GameObject("Mansion").transform;
        foreach (Rooms room in bldg.Rooms)
        {
            RenderRoom(room);
        }
    }

    private void RenderRoom(Rooms room)
    {
        Transform roomFolder = new GameObject("Room").transform;
        roomFolder.SetParent(mnsnFolder);
        foreach (Clue clue in room.Clues)
        {
            //RenderClues(clue, room, roomFolder);
        }
        //RenderTheme(room, roomFolder);
    }
}
