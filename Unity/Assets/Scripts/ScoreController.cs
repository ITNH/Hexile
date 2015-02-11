using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int level;

    private string state;
    private int counter;
    private int timer;
    private bool[] rows = new bool[15];

    private BoardController board;

    void Start()
    {

        board = GameController.boardcontroller;

        score = 0;
        level = 1;

    }

    void Update()
    {

        switch (state)
        {

            case "tick":

                state = "check";
                break;

            case "check":

                bool isrow = false;
                
                for (int row = 0; row < 15; row++)
                {

                    bool thisrow = true;
                    
                    for (int col = 0; col < 15; col++)
                    {

                        if (!board.IsHex(col, row))
                        {

                            thisrow = false;
                            col = 15;

                        }

                    }

                    if (thisrow)
                        isrow = true;

                    rows[row] = thisrow;

                }

                if (isrow)
                {

                    state = "blink";
                    timer = 59;
                    counter = 0;

                }
                else
                {

                    state = null;
                    GameController.SpawnHexel();

                }

                break;

            case "blink":

                timer++;

                if (counter == 2)
                {

                    state = null;

                }

                if (timer == 60)
                {

                    timer = 0;
                    counter++;

                }

                if (timer == 0)
                {

                    for (int row = 0; row < 15; row++)
                    {

                        if (rows[row])
                        {

                            for (int col = 0; col < 15; col++)
                            {

                                board.hideHex(col, row);

                            }

                        }

                    }

                }

                if (timer == 30)
                {

                    for (int row = 0; row < 15; row++)
                    {

                        if (rows[row])
                        {

                            for (int col = 0; col < 15; col++)
                            {

                                board.showHex(col, row);

                            }

                        }

                    }

                }

                break;
            
            default:
                break;

        }

    }

    // Called when a hexel sets
    public void Trigger() 
    {

        state = "tick";
        
    }

}
