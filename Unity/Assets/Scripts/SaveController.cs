using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Controller for managing all persistent data (saves, highscores, etc.)
public class SaveController : MonoBehaviour {

    // Saves the given data object to save.dat
	public void SaveGame(GameSaveDataObject savedataobject)
    {

        // Create a formatter for serializing the data
        BinaryFormatter formatter = new BinaryFormatter();

        // Create the save file
        FileStream savefile = File.Create(Application.persistentDataPath + "/save.dat");

        // Serialize and save the data
        formatter.Serialize(savefile, savedataobject);

        // Close the save file
        savefile.Close();

    }

    public GameSaveDataObject LoadGame()
    {

        // Check that the save file actually exists
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {

            // Create a formatter for deserializing the data
            BinaryFormatter formatter = new BinaryFormatter();

            // Open the save file
            FileStream savefile = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            // Deserialize the save file
            GameSaveDataObject savedata = (GameSaveDataObject)formatter.Deserialize(savefile);

            // Close the save file
            savefile.Close();

            return savedata;

        }
        else
        {

            // If the file isn't there because derp, return an empty game
            return new GameSaveDataObject();

        }

    }

    public bool IsGameSaved()
    {

        return File.Exists(Application.persistentDataPath + "/save.dat");

    }

}
