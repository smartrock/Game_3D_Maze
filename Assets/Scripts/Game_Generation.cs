using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;

public class Game_Generation : MonoBehaviour
{
    public List<GameObject> innocentWeapons = new List<GameObject>();
    public List<GameObject> innocentSuspects = new List<GameObject>();
    public List<string> innocentRooms = new List<string>();
    public List<Vector3> suspectLocations = new List<Vector3>();
    public List<Vector3> weaponsLocations = new List<Vector3>();
    
    public GameObject chosenWeapon;
    public GameObject chosenSuspect;
    public TextMeshProUGUI suspectText;
    public string chosenRoom;

    // Start is called before the first frame update
    void Start()
    {
        int chosenWeaponID = Random.Range(0, innocentWeapons.Count - 1);
        chosenWeapon = innocentWeapons[chosenWeaponID];
        innocentWeapons.RemoveAt(chosenWeaponID);

        int chosenSuspectID = Random.Range(0, innocentSuspects.Count - 1);
        chosenSuspect = innocentSuspects[chosenSuspectID];
        innocentSuspects.RemoveAt(chosenSuspectID);

        int chosenRoomID = Random.Range(0, innocentRooms.Count - 1);
        chosenRoom = innocentRooms[chosenRoomID];
        innocentRooms.RemoveAt(chosenRoomID);

        foreach(var weapon in innocentWeapons)
        {
            GameObject newWeapon = Instantiate(weapon);
            int weaponPositionID = Random.Range(0, weaponsLocations.Count - 1);
            newWeapon.transform.position = weaponsLocations[weaponPositionID];
            weaponsLocations.RemoveAt(weaponPositionID);
        }
        foreach (var suspect in innocentSuspects)
        {
            GameObject newSuspect = Instantiate(suspect);
            newSuspect.AddComponent<BoxCollider>();
            newSuspect.AddComponent<Game_Generation>();
            int suspectPositionID = Random.Range(0, suspectLocations.Count - 1);
            newSuspect.transform.position = suspectLocations[suspectPositionID];
            suspectLocations.RemoveAt(suspectPositionID);
        }

        Debug.Log("It was " + chosenSuspect + " with the " + chosenWeapon + " in the " + chosenRoom);
    }

    public void CharacterLines()
    {
        suspectText.text = "";
        string speak = "I saw " + " in the ";
        suspectText.text = speak;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
