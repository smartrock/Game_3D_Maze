using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public static void ReadFile()
    {
        string path = Application.persistentDataPath + "/highscores.txt";
        StreamReader streamReader = new StreamReader(path);
        Debug.Log(streamReader.ReadToEnd());
        streamReader.Close();
    }
}
