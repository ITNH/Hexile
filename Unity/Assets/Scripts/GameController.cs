using UnityEngine;
using System.Collections;
using System;

// Controller for managing in-game data and events
public class GameController : MonoBehaviour
{

    [HideInInspector]
    public int score { get; private set; }
    [HideInInspector]
    public int level { get; private set; }

    private static System.Random random = new System.Random();

    // Variables for maintaining the state engine
    private GameObject currenthexel = null;
    private string gamestate = "stopped";
    bool[] rows = new bool[15];
    int timer = 0;
    int counter = 0;

    void Update()
    {

        switch (gamestate)
        {

            case "stopped":
                break;

            case "start":

                gamestate = "spawnhexel";

                break;


            case "spawnhexel":

                currenthexel = Instantiate(GameManager.hexelprefabs[random.Next(0, GameManager.hexelprefabs.Length)], new
                    Vector3(0, 0), Quaternion.identity) as GameObject;

                gamestate = "running";

                break;

            case "running":
                break;

            case "linecheck":

                Destroy(currenthexel);

                rows = GameManager.rowcontroller.CheckForRows();

                bool isRow = false;

                for (int row = 0; row < 15; row++)
                {

                    if (rows[row])
                        isRow = true;

                }

                if (isRow)
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

            default:
                break;

        }

    }

    public void NewGame()
    {

        gamestate = "start";

    }
    
    public void SetHexel()
    {

        gamestate = "linecheck";

    }

}
