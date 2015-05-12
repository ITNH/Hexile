using UnityEngine;
using System.Collections;

// Controller for tracking and managing hexes on the board in-game
public class BoardController : MonoBehaviour
{
    
    // Array of references to each hex's GameObject
    private GameObject[,] hexobjects = new GameObject[15, 20];

    // Array indicating the color of each hex on the grid, 0 meaning empty
    public int[,] colorgrid = new int[15, 20];

    public bool AddHex(int xpos, int ypos, int color)
    {

        if (hexobjects[xpos, ypos] == null)
        {

            hexobjects[xpos, ypos] = Instantiate(GameManager.hexprefabs[color], new
                Vector3(GetXCoord(xpos), GetYCoord(xpos, ypos)),
                Quaternion.identity) as GameObject;

            colorgrid[xpos, ypos] = color;

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool RemoveHex(int xpos, int ypos)
    {

        if (hexobjects[xpos, ypos] != null)
        {

            Destroy(hexobjects[xpos, ypos]);
            hexobjects[xpos, ypos] = null;

            colorgrid[xpos, ypos] = 0;

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool MoveHex(int x1, int y1, int x2, int y2)
    {

        if (hexobjects[x1, y1] != null && hexobjects[x2, y2] == null)
        {

            hexobjects[x2, y2] = hexobjects[x1, y1];
            colorgrid[x2, y2] = colorgrid[x1, y1];

            hexobjects[x1, y1] = null;
            colorgrid[x1, y1] = 0;

            hexobjects[x2, y2].transform.position = new Vector3(GetXCoord(x2), GetYCoord(x2, y2));

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool IsHex(int xpos, int ypos)
    {

        if (xpos < 0 || xpos > 14 || ypos < 0)
        {

            return true;

        }
        else
        {

            if (hexobjects[xpos, ypos] != null)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

    }

    public GameObject getHex(int xpos, int ypos)
    {

        return hexobjects[xpos, ypos];

    }

    public int getHexColor(int xpos, int ypos)
    {

        return colorgrid[xpos, ypos];

    }

    public bool hideHex(int xpos, int ypos)
    {

        if (hexobjects[xpos, ypos] == null)
        {

            return false;

        }
        else
        {

            hexobjects[xpos, ypos].GetComponent<Renderer>().enabled = false;

            return true;

        }

    }

    public bool showHex(int xpos, int ypos)
    {

        if (hexobjects[xpos, ypos] == null)
        {

            return false;

        }
        else
        {

            hexobjects[xpos, ypos].GetComponent<Renderer>().enabled = true;

            return true;

        }

    }

    // Utility functions for converting grid coordinates to on-screen coordinates
    public int GetXCoord(int xpos)
    {

        return (14 * xpos) + 1;

    }

    public int GetYCoord(int xpos, int ypos)
    {

        if (xpos % 2 == 0)
        {
            // even
            return (16 * ypos) + 9;
        }
        else
        {
            // odd
            return (16 * ypos) + 1;
        }

    }

    public int[,] GetGrid()
    {

        return colorgrid;

    }

    public void LoadGrid(int[,] grid)
    {

        for (int row = 0; row < 20; row++)
        {

            for (int col = 0; col < 15; col++)
            {

                if (grid[col, row] != 0)
                {

                    AddHex(col, row, grid[col, row]);

                }

            }

        }

    }

}
