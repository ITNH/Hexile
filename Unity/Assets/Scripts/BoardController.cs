using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour
{

    public GameObject[] hexagons;
    
    private static GameObject[,] grid = new GameObject[15, 20];

    public bool AddHex(int xpos, int ypos, int color)
    {

        if (grid[xpos, ypos] == null)
        {

            grid[xpos, ypos] = Instantiate(hexagons[color], new
                Vector3(GetXCoord(xpos), GetYCoord(xpos, ypos)),
                Quaternion.identity) as GameObject;

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool RemoveHex( int xpos, int ypos)
    {

        if ( grid[xpos, ypos] != null )
        {

            Destroy(grid[xpos, ypos]);

            grid[xpos, ypos] = null;

            return true;

        }
        else
        {

            return false;

        }

	}

    public bool MoveHex(int x1, int y1, int x2, int y2)
    {

        if ( grid[x1, y1] != null && grid[x2, y2] == null )
        {

            grid[x2, y2] = grid[x1, y1];

            grid[x1, y1] = null;

            grid[x2, y2].transform.position = new Vector3(GetXCoord(x2), GetYCoord(x2, y2));

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool IsHex( int xpos, int ypos )
    {

        if (xpos < 0 || xpos > 14 || ypos < 0)
        {

            return true;

        }
        else
        {

            if (grid[xpos, ypos] != null)
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

        return grid[xpos, ypos];

    }

    public bool hideHex(int xpos, int ypos)
    {

        if (grid[xpos, ypos] == null)
        {

            return false;

        }
        else
        {

            grid[xpos, ypos].renderer.enabled = false;

            return true;

        }

    }

    public bool showHex(int xpos, int ypos)
    {

        if (grid[xpos, ypos] == null)
        {

            return false;

        }
        else
        {

            grid[xpos, ypos].renderer.enabled = true;

            return true;

        }

    }

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

}
