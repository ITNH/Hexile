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
                    timer = 0;
                    counter = 0;

                }
                else
                {

                    state = null;
                    GameController.SpawnHexel();

                }

                break;

            case "blink":

                if (counter == 2)
                {

                    state = "clear";

                }
                else
                {

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

                    timer++;

                    if (timer == 60)
                    {

                        timer = 0;
                        counter++;

                    }

                }

                break;

            case "clear":

                counter = 0;

                for (int row = 0; row < 15; row++)
                {

                    if (rows[row])
                    {

                        for (int col = 0; col < 15; col++)
                        {

                            board.RemoveHex(col, row);

                        }

                    }

                }

                state = "wait";
                timer = 0;
                
                break;

            case "wait":

                timer++;

                if (timer == 60)
                    state = "drop";

                break;

            case "drop":

                for (int row = 0; row < 15; row++)
                {

                    if (rows[row])
                        counter++;

                    for (int drops = 0; drops < counter; drops++)
                    {

                        for (int col = 0; col < 15; col++)
                        {

                            board.MoveHex(col, row - drops, col, row - drops - 1);

                        }

                    }

                }

                timer = 0;
                state = "cascade";

                break;

            case "cascade":

                timer++;

                if (timer == 60)
                    state = "check";

                break;
            
            default:
                break;

        }

    }

    // Called when a hexel sets
    public void Trigger() 
    {

        state = "check";
        
    }

}
