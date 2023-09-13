using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;

public class Game_Generation : MonoBehaviour
{
    // A list of all the possible Weapon gameobjects and suspect gameobjects
    public List<GameObject> innocentWeapons = new List<GameObject>();
    public List<GameObject> innocentSuspects = new List<GameObject>();

    // A list of all the rooms as a string
    public List<string> innocentRooms = new List<string>();

    // A list of all the suspects that can be used in character lines
    public List<string> speakSuspects = new List<string>();

    // A list of all the rooms that can be used in character lines
    public List<string> speakRooms = new List<string>();

    // A lis of all the possible starting locations for the suspects and weapons
    public List<Vector3> suspectLocations = new List<Vector3>();
    public List<Vector3> weaponsLocations = new List<Vector3>();
    
    // The chosen murder weapon and person
    public GameObject chosenWeapon;
    public GameObject chosenSuspect;

    // The text box where the character lines will be printed
    public TextMeshProUGUI suspectText;

    // The murder room that has been chosen
    public string chosenRoom;

    // Start is called before the first frame update
    void Start()
    {
        // Picks a random number in the weapons list
        int chosenWeaponID = Random.Range(0, innocentWeapons.Count - 1);
        // Uses the number of the weapon in the list as the murder weapon
        chosenWeapon = innocentWeapons[chosenWeaponID];
        // Removes the murder weapon from the other weapons
        innocentWeapons.RemoveAt(chosenWeaponID);

        // Picks a random number in the suspects list
        int chosenSuspectID = Random.Range(0, innocentSuspects.Count - 1);
        // Uses the number of the suspect in the list as the murderer
        chosenSuspect = innocentSuspects[chosenSuspectID];
        // Removes the murderer from the other suspects
        innocentSuspects.RemoveAt(chosenSuspectID);

        // Picks a random number in the rooms list
        int chosenRoomID = Random.Range(0, innocentRooms.Count - 1);
        // Uses the number of the room in the list as the murder room
        chosenRoom = innocentRooms[chosenRoomID];
        // Removes the murder room from the other rooms
        innocentRooms.RemoveAt(chosenRoomID);

        // Spawns in all the innocent weapons
        foreach(GameObject weapon in innocentWeapons)
        {
            // Puts a copy of the weapon in the game
            GameObject newWeapon = Instantiate(weapon);
            // Finds a random position from a set list
            int weaponPositionID = Random.Range(0, weaponsLocations.Count - 1);
            // Puts the weapon in its random position
            newWeapon.transform.position = weaponsLocations[weaponPositionID];
            // Removes the used position from the weapons locations
            weaponsLocations.RemoveAt(weaponPositionID);
        }

        // Repeats for each of the innocent suspects
        foreach (GameObject o in innocentSuspects)
        {
            // Gives the specific characters name and adds it to a list of characters own names
            speakSuspects.Add(o.name);
        }

        // Repeats for each of the innocent rooms
        foreach (string s in innocentRooms)
        {
            // Gives the specific room name and adds it to a list of room names
            speakRooms.Add(s);
        }
        speakRooms = innocentRooms;

        // Spawns in all the innocent suspects
        foreach (GameObject suspect in innocentSuspects)
        {
            // Puts a copy of the suspect in the game
            GameObject newSuspect = Instantiate(suspect);
            // Finds a random position for this character
            int suspectPositionID = Random.Range(0, suspectLocations.Count - 1);
            // Puts the character in its random place
            newSuspect.transform.position = suspectLocations[suspectPositionID];
            // Removes the position from the list
            suspectLocations.RemoveAt(suspectPositionID);

            // Finds a random innocent person that will be part of the  charcters unique line
            int speakSuspectID = Random.Range(0, speakSuspects.Count - 1);
            // Turns the suspects id into their name
            string speakSuspect = speakSuspects[speakSuspectID];
            // Removes that suspect from the suspects character lines options
            speakSuspects.RemoveAt(speakSuspectID);

            // Finds a random innocent room to assign with the random character 
            int speakRoomID = Random.Range(0, speakRooms.Count - 1);
            // Converts the room id into its name
            string speakRoom = speakRooms[speakRoomID];
            // Removes that room from the rooms that characters can say
            speakRooms.RemoveAt(speakRoomID);

            // Gets the speak string for the suspect from the suspect script
            newSuspect.GetComponent<SuspectScript>().speekSuspect = speakSuspect;
            // Gets the speak string for the room from the suspect script
            newSuspect.GetComponent<SuspectScript>().speekRoom = speakRoom;
            // Gets the text reference to the text box on the game screen from the suspect script
            newSuspect.GetComponent<SuspectScript>().suspectText = suspectText;
        }
    }
}
