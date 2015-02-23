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

    public bool DeleteSave()
    {

        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {

            File.Delete(Application.persistentDataPath + "/save.dat");

            return true;

        }
        else
        {

            return false;

        }

    }

    // Saves the given data object to save.dat
    public void SaveHighScores(HighScoreDataObject highscoredataobject)
    {

        // Create a formatter for serializing the data
        BinaryFormatter formatter = new BinaryFormatter();

        // Create the save file
        FileStream savefile = File.Create(Application.persistentDataPath + "/highscores.dat");

        // Serialize and save the data
        formatter.Serialize(savefile, highscoredataobject);

        // Close the save file
        savefile.Close();

    }

    public HighScoreDataObject LoadHighScores()
    {

        // Check that the save file actually exists
        if (File.Exists(Application.persistentDataPath + "/highscores.dat"))
        {

            // Create a formatter for deserializing the data
            BinaryFormatter formatter = new BinaryFormatter();

            // Open the save file
            FileStream savefile = File.Open(Application.persistentDataPath + "/highscores.dat",
                FileMode.Open);

            // Deserialize the save file
            HighScoreDataObject savedata = (HighScoreDataObject)formatter.Deserialize(savefile);

            // Close the save file
            savefile.Close();

            return savedata;

        }
        else
        {

            // If the file isn't there because derp, return a highscore of 0
            return new HighScoreDataObject(0);

        }

    }

    public bool IsHighScoreSaved()
    {

        return File.Exists(Application.persistentDataPath + "/highscores.dat");

    }

}

[Serializable]
public class GameSaveDataObject
{

    public string gamestate { get; private set; }
    public int score { get; private set; }
    public int level { get; private set; }
    public int lines { get; private set; }
    public bool[] rows { get; private set; }
    public int hexelcolor { get; private set; }
    public int nexthexel { get; private set; }
    public int[,] grid { get; private set; }

    public GameSaveDataObject()
    {

        this.gamestate = "stopped";
        this.score = 0;
        this.level = 0;
        this.lines = 0;
        this.rows = new bool[15];
        this.hexelcolor = 0;
        this.nexthexel = 0;
        this.grid = new int[15, 20];

    }

    public GameSaveDataObject(string gamestate, int score, int level, int lines, bool[] rows,
        int hexelcolor, int nexthexel, int[,] grid)
    {

        this.gamestate = gamestate;
        this.score = score;
        this.level = level;
        this.lines = lines;
        this.rows = rows;
        this.hexelcolor = hexelcolor;
        this.nexthexel = nexthexel;
        this.grid = grid;

    }

}

[Serializable]
public class HighScoreDataObject
{

    public int highscore { get; private set; }

    public HighScoreDataObject(int highscore)
    {

        this.highscore = highscore;

    }

}
