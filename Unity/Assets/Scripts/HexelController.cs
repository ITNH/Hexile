using UnityEngine;
using System.Collections;

public class HexelController : MonoBehaviour
{

    public int basespeed;
    public int dropspeed;
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
    private int speed;

    private GameObject[] hexes = new GameObject[8];

    private BoardController board;

    void Start()
    {

        counter = 0;
        rotation = 0;
        speed = basespeed;

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
        if (counter >= speed)
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

                    if ((xoffset % 2 != 0) && ((rarray[i] + xoffset) % 2 == 0))
                    {
                        board.AddHex(rarray[i] + xoffset, rarray[i + 4] + (yoffset - 1), color);
                    }
                    else
                    {
                        board.AddHex(rarray[i] + xoffset, rarray[i + 4] + yoffset, color);
                    }

                    Destroy(hexes[i]);

                }

                GameController.DestroyHexel();

            }

        }
         // Drop it like it's hot!
        if (Input.GetButton("Down"))
        {

            speed = dropspeed;

        }
        else
        {

            speed = basespeed - GameController.scorecontroller.level;

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

        // Twist it!
        if (Input.GetButtonDown("RotateR") && !Input.GetButtonDown("RotateL"))
        {

            int newrotation = rotation + 60;
            if (newrotation >= 360)
                newrotation = 0;

            // Is there something there?
            if (!CheckMove(xoffset, yoffset, newrotation))
            {

                // Move it!
                DoMove(xoffset, yoffset, newrotation);

                rotation = newrotation;

            }

        }

        // The other way!
        if (Input.GetButtonDown("RotateL") && !Input.GetButtonDown("RotateR"))
        {

            int newrotation = rotation - 60;
            if (newrotation <= -60)
                newrotation = 300;

            // Is there something there?
            if (!CheckMove(xoffset, yoffset, newrotation))
            {

                // Move it!
                DoMove(xoffset, yoffset, newrotation);

                rotation = newrotation;

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
                Debug.Log("Warning: HexelController.GetRotateArray was passed an invalid value: " + rotation.ToString());
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

            if ((xoffset % 2 != 0) && ((rarray[i] + xoffset) % 2 == 0))
            {

                if (board.IsHex(rarray[i] + xoffset, rarray[i + 4] + (yoffset - 1)))
                {

                    flag = true;

                }

            }
            else
            {

                if (board.IsHex(rarray[i] + xoffset, rarray[i + 4] + yoffset))
                {

                    flag = true;

                }

            }

        }

        return flag;

    }

    private void DoMove(int xoffset, int yoffset, int rotation)
    {

        // turn 12 function calls into 1 (Yay optimization!)
        int[] rarray = GetRotateArray(rotation);

        for (int i = 0; i < 4; i++)
        {

            if ((xoffset % 2 != 0) && ((rarray[i] + xoffset) % 2 == 0))
            {
                hexes[i].transform.position = new Vector3(board.GetXCoord(rarray[i] + xoffset),
                board.GetYCoord(rarray[i] + xoffset, rarray[i + 4] + (yoffset - 1)));
            }
            else
            {
                hexes[i].transform.position = new Vector3(board.GetXCoord(rarray[i] + xoffset),
                board.GetYCoord(rarray[i] + xoffset, rarray[i + 4] + yoffset));
            }

        }

    }

}
