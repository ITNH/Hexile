using UnityEngine;
using System;
using System.Collections;

public class HexelController : MonoBehaviour
{

    // Property definitions, to be defined in the inspector
    public int color;
    public int xstart;
    public int ystart;
    public int basespeed;
    public int dropspeed;

    /* Shape definitions, to be defined in the inspector
     * All hexels should rotate around 0,0
     * Format: {x1,x2,x3,x4,y1,y2,y3,y4}
     */
    public int[] Rotate0;
    public int[] Rotate60;
    public int[] Rotate120;
    public int[] Rotate180;
    public int[] Rotate240;
    public int[] Rotate300;

    // Variables for tracking the hexel's current state
    private int rotation;
    private int xpos;
    private int ypos;

    // Variables for timing downward movement
    private int dropcounter;
    private int currentspeed;

    // Scoring-related variables
    public int drops { get; private set; }
    public int softdrops { get; private set; }

    private GameObject[] hexes = new GameObject[4];

    void Start()
    {

        // Set coordinates
        xpos = xstart;
        ypos = ystart;
        rotation = 0;

        // Create hex objects
        for (int i = 0; i < 4; i++)
        {

            hexes[i] = Instantiate(GameManager.hexprefabs[color], new
                Vector3(300, 300), Quaternion.identity) as GameObject;

        }

        // Put 'em on screen!
        SetHexCoords(xpos, ypos, rotation);

    }

    void Update()
    {

        dropcounter++;

        // Drop it like it's hot!
        if (Input.GetButton("Down"))
        {

            currentspeed = dropspeed;

        }
        else
        {

            currentspeed = basespeed - (GameManager.gamecontroller.level * 5);

        }

        // If it's time to drop...
        if (dropcounter >= currentspeed)
        {

            dropcounter = 0;

            // Gravity check!
            if (!CheckPosition(xpos, ypos - 1, rotation))
            {

                // Bring it down!
                SetHexCoords(xpos, ypos - 1, rotation);

                ypos--;

                if (Input.GetButton("Down"))
                    softdrops++;

                drops++;

            }
            else
            {

                // Turn 8 function calls into 1 (Yay optimization!)
                int[] rarray = GetRotateArray(rotation);

                // Set it!
                for (int i = 0; i < 4; i++)
                {

                    if ((xpos % 2 != 0) && ((rarray[i] + xpos) % 2 == 0))
                    {
                        GameManager.boardcontroller.AddHex(rarray[i] + xpos, rarray[i + 4] + (ypos - 1), color);
                    }
                    else
                    {
                        GameManager.boardcontroller.AddHex(rarray[i] + xpos, rarray[i + 4] + ypos, color);
                    }

                    Destroy(hexes[i]);

                }

                // Notify GameController that we've set, telling them if we haven't moved
                GameManager.gamecontroller.SetHexel(xpos == xstart && ypos == ystart);

            }

        }

        // To the left, to the left!
        if (Input.GetButtonDown("Left") && !Input.GetButtonDown("Right"))
        {

            // Is there something there?
            if (!CheckPosition(xpos - 1, ypos, rotation))
            {

                // Move it!
                SetHexCoords(xpos - 1, ypos, rotation);

                xpos--;

            }

        }

        // To the right, too the right!
        if (Input.GetButtonDown("Right") && !Input.GetButtonDown("Left"))
        {

            // Is there something there?
            if (!CheckPosition(xpos + 1, ypos, rotation))
            {

                // Move it!
                SetHexCoords(xpos + 1, ypos, rotation);

                xpos++;

            }

        }

        // Twist it!
        if (Input.GetButtonDown("RotateR") && !Input.GetButtonDown("RotateL"))
        {

            int newrotation = rotation + 60;
            if (newrotation >= 360)
                newrotation = 0;

            // Is there something there?
            if (!CheckPosition(xpos, ypos, newrotation))
            {

                // Move it!
                SetHexCoords(xpos, ypos, newrotation);

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
            if (!CheckPosition(xpos, ypos, newrotation))
            {

                // Move it!
                SetHexCoords(xpos, ypos, newrotation);

                rotation = newrotation;

            }

        }

    }

    // Returns the correct shape definition based on the given rotation
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

    // Checks whether the given position will result in a collision
    private bool CheckPosition(int xoffset, int yoffset, int rotation)
    {

        bool flag = false;

        // turn 8 function calls into 1 (Yay optimization!)
        int[] rarray = GetRotateArray(rotation);

        for (int i = 0; i < 4; i++)
        {

            if ((xoffset % 2 != 0) && ((rarray[i] + xoffset) % 2 == 0))
            {

                if (GameManager.boardcontroller.IsHex(rarray[i] + xoffset, rarray[i + 4] + (yoffset - 1)))
                {

                    flag = true;

                }

            }
            else
            {

                if (GameManager.boardcontroller.IsHex(rarray[i] + xoffset, rarray[i + 4] + yoffset))
                {

                    flag = true;

                }

            }

        }

        return flag;

    }

    // Sets the on-screen coordinates of the hexes
    private void SetHexCoords(int xoffset, int yoffset, int rotation)
    {

        // turn 12 function calls into 1 (Yay optimization!)
        int[] rarray = GetRotateArray(rotation);

        for (int i = 0; i < 4; i++)
        {

            if ((xoffset % 2 != 0) && ((rarray[i] + xoffset) % 2 == 0))
            {

                hexes[i].transform.position = new Vector3(GameManager.boardcontroller.GetXCoord(rarray[i] + xoffset),
                GameManager.boardcontroller.GetYCoord(rarray[i] + xoffset, rarray[i + 4] + (yoffset - 1)));

            }
            else
            {

                hexes[i].transform.position = new Vector3(GameManager.boardcontroller.GetXCoord(rarray[i] + xoffset),
                GameManager.boardcontroller.GetYCoord(rarray[i] + xoffset, rarray[i + 4] + yoffset));

            }

        }

    }

}
