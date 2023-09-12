using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
    public static void SaveTime(GameLogic logic)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscores";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(logic);

        formatter.Serialize(fileStream, logic);
        fileStream.Close();
    }

    public static PlayerData LoadScores ()
    {
        string path = Application.persistentDataPath + "/highscores";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
