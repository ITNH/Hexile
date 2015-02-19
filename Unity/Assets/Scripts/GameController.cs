﻿using UnityEngine;
using System;
using System.Collections;

// Controller for managing in-game data and events
public class GameController : MonoBehaviour
{

    // Scoring variables, globally readable but only settable internally
    [HideInInspector]
    public int score { get; private set; }
    [HideInInspector]
    public int level { get; private set; }
    [HideInInspector]
    public int lines { get; private set; }

    // Constant array of numbers for scoring
    private int[] linescores = { 0, 40, 100, 300, 1200 };

    // Reference to the current hexel's GameObject
    private GameObject currenthexel;

    // Reference to the currently active HexelController
    private HexelController hexelcontroller;

    // RNG for spawning hexels
    private static System.Random random = new System.Random();

    // Variables for maintaining the state engine
    private string gamestate = "stopped";
    bool[] rows = new bool[15];
    int timer = 0;
    int counter = 0;
    int hexelcolor = 0;
    int nexthexel = 0;

    void Update()
    {

        switch (gamestate)
        {

            case "stopped":
                break;

            case "start":

                hexelcolor = random.Next(0, GameManager.hexelprefabs.Length);

                gamestate = "spawnhexel";

                break;

            case "spawnhexel":

                hexelcolor = nexthexel;
                nexthexel = random.Next(0, GameManager.hexelprefabs.Length);
                currenthexel = Instantiate(GameManager.hexelprefabs[hexelcolor], new
                    Vector3(0, 0), Quaternion.identity) as GameObject;

                hexelcontroller = currenthexel.GetComponent<HexelController>();

                gamestate = "running";

                break;

            case "running":

                break;

            case "linecheck":

                Destroy(currenthexel);
                currenthexel = null;
                hexelcontroller = null;

                rows = GameManager.rowcontroller.CheckForRows();

                int numrows = 0;

                for (int row = 0; row < 15; row++)
                {

                    if (rows[row])
                        numrows++;

                }

                score += linescores[numrows] * (level + 1);
                level = lines / 10;
                lines += numrows;

                Debug.Log(score + " " + level + " " + lines);

                if (numrows != 0)
                {

                    timer = 0;
                    counter = 0;
                    gamestate = "lineblink";

                }
                else
                {

                    gamestate = "spawnhexel";

                }

                break;

            case "lineblink":

                if (counter == 2)
                {

                    gamestate = "lineclear";

                }
                else
                {

                    if (timer == 0)
                        GameManager.rowcontroller.HideRows(rows);

                    if (timer == 25)
                        GameManager.rowcontroller.ShowRows(rows);

                    if (timer == 50)
                    {

                        timer = 0;
                        counter++;

                    }
                    else
                    {

                        timer++;

                    }

                }

                break;

            case "lineclear":

                GameManager.rowcontroller.ClearRows(rows);

                timer = 0;
                gamestate = "waitfordrop";

                break;

            case "waitfordrop":

                timer++;

                if (timer == 60)
                    gamestate = "droplines";

                break;

            case "droplines":

                GameManager.rowcontroller.DropRows(rows);

                gamestate = "spawnhexel";

                break;

            case "gameover":
                
                Destroy(currenthexel);
                currenthexel = null;
                hexelcontroller = null;

                counter = 0;
                rows = new bool[20];

                gamestate = "fill";

                break;

            case "fill":

                rows[counter] = true;

                counter++;

                GameManager.rowcontroller.FillRows(rows, 0);

                if (counter >= 20)
                {

                    rows = new bool[20];
                    counter = 0;

                    gamestate = "wipe";

                }

                break;

            case "wipe":

                rows[counter] = true;

                counter++;

                GameManager.rowcontroller.ClearRows(rows);

                if (counter >= 20)
                {

                    counter = 0;

                    gamestate = "end";

                }

                break;

            case "end":

                if (Input.GetButtonDown("Select"))
                    NewGame();

                break;

            default:
                break;

        }

    }

    void OnDisable()
    {

        if (gamestate == "running")
        {

            GameManager.savecontroller.SaveGame(new GameSaveDataObject(
                gamestate, score, level, lines, rows, hexelcolor, nexthexel,
                GameManager.boardcontroller.GetGrid()));

        }

    }

    public void NewGame()
    {

        gamestate = "start";

    }

    public void LoadGame()
    {

        GameSaveDataObject savedata = GameManager.savecontroller.LoadGame();

        gamestate = savedata.gamestate;
        score = savedata.score;
        level = savedata.level;
        rows = savedata.rows;
        hexelcolor = savedata.hexelcolor;
        GameManager.boardcontroller.LoadGrid(savedata.grid);

        switch (gamestate)
        {

            case "running":
                
                currenthexel = Instantiate(GameManager.hexelprefabs[hexelcolor], new
                    Vector3(0, 0), Quaternion.identity) as GameObject;

                hexelcontroller = currenthexel.GetComponent<HexelController>();
                
                break;

            case "lineblink":

                timer = 0;
                counter = 0;

                break;

            case "waitfordrop":

                timer = 0;

                break;

            default:
                break;

        }

    }

    public void SetHexel()
    {

        gamestate = "linecheck";

    }

    public void GameOver()
    {

        gamestate = "gameover";

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
        this.grid = new int[15,20];

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
