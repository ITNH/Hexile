using UnityEngine;
using System.Collections;


public class HexelController : MonoBehaviour
{

    public int color;
    public int xoffset;
    public int yoffset;

    // shape definitions
    // {x1,x2,x3,x4,y1,y2,y3,y4}
    public int[] Rotate0;
    public int[] Rotate60;
    public int[] Rotate120;
    public int[] Rotate180;
    public int[] Rotate240;
    public int[] Rotate300;

    private int counter;
    private int rotation;

    private GameObject[] hexes = new GameObject[8];

    private BoardController board;

    void Start()
    {

        counter = 0;
        rotation = 0;

        board = GameController.boardcontroller;
        
        // Make dem hexes!
        for (int i = 0; i < 4; i++)
        {
            
            hexes[i] = Instantiate(board.hexagons[color], new
                Vector3(300, 300), Quaternion.identity) as GameObject;

        }

        // Put 'em on screen!
        DoMove(xoffset, yoffset, rotation);

    }

    void Update()
    {

        counter++;

        // If it's time to drop...
        if (counter >= GameController.speed)
        {

            counter = 0;

            // Gravity check!
            if (!CheckMove(xoffset, yoffset - 1, rotation))
            {

                // Bring it down!
                DoMove(xoffset, yoffset - 1, rotation);

                yoffset--;

            }
            else
            {
                
                // Turn 8 function calls into 1 (Yay optimization!)
                int[] rarray = GetRotateArray(rotation);

                // Set it!
                for (int i = 0; i < 4; i++)
                {

                    board.AddHex(rarray[i] + xoffset, rarray[i + 4] + yoffset, color);

                    Destroy(hexes[i]);

                }

                Destroy(transform.root.gameObject);

            }

        }

        // To the left, to the left!
        if (Input.GetButtonDown("Left") && !Input.GetButtonDown("Right"))
        {

            // Is there something there?
            if (!CheckMove(xoffset - 1, yoffset, rotation))
            {

                // Move it!
                DoMove(xoffset - 1, yoffset, rotation);

                xoffset--;

            }

        }

        // To the right, too the right!
        if (Input.GetButtonDown("Right") && !Input.GetButtonDown("Left"))
        {

            // Is there something there?
            if (!CheckMove(xoffset + 1, yoffset, rotation))
            {

                // Move it!
                DoMove(xoffset + 1, yoffset, rotation);

                xoffset++;

            }

        }

    }


    private int[] GetRotateArray(int rotation)
    {

        switch (rotation)
        {

            case 0:
                return Rotate0;

            case 60:
                return Rotate60;

            case 120:
                return Rotate120;

            case 180:
                return Rotate180;

            case 240:
                return Rotate240;

            case 300:
                return Rotate300;

            default:
                Debug.Log("Warning: HexelController.GetRotateArray was passed an invalid value!");
                return null;

        }

    }
    private bool CheckMove(int xoffset, int yoffset, int rotation)
    {

        bool flag = false;

        // turn 8 function calls into 1 (Yay optimization!)
        int[] rarray = GetRotateArray(rotation);

        for (int i = 0; i < 4; i++)
        {

            if (board.IsHex(rarray[i] + xoffset, rarray[i + 4] + yoffset))
                flag = true;

        }

        return flag;

    }

    private void DoMove(int xoffset, int yoffset, int rotation)
    {

        // turn 12 function calls into 1 (Yay optimization!)
        int[] rarray = GetRotateArray(rotation);

        for (int i = 0; i < 4; i++)
        {

            hexes[i].transform.position = new Vector3(board.GetXCoord(rarray[i] + xoffset),
                board.GetYCoord(rarray[i] + xoffset, rarray[i + 4] + yoffset));

        }

    }

}
