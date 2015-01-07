using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

    public GameObject[] hexagons;

    private static int[] xcoords = new int[] { 1, 15, 29, 43, 57, 71, 85, 99, 113, 127, 141, 155, 169, 183, 197, };
    private static int[] ycoords = new int[] { 9, 25, 41, 57, 73, 89, 105, 121, 137, 153, 169, 185, 201, 217, 233, };

    private static GameObject[,] grid = new GameObject[15, 15];

    public bool AddHex(int xpos, int ypos, int color)
    {

        if (grid[xpos, ypos] == null)
        {

            if (xpos % 2 == 0) // if xpos is even
            {
                grid[xpos, ypos] = Instantiate( hexagons[color], new
                    Vector3( xcoords[xpos], ycoords[ypos] ),
                    Quaternion.identity ) as GameObject;
            }
            else // if xpos is odd
            {
                grid[xpos, ypos] = Instantiate( hexagons[color], new
                    Vector3( xcoords[xpos], ycoords[ypos] - 8 ), // offset for odd hexes
                    Quaternion.identity ) as GameObject;
            }

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

            if (x2 % 2 == 0)
            {
                grid[x2, y2].transform.position = new
                    Vector3( xcoords[x2], ycoords[y2] );
            }
            else
            {
                grid[x2, y2].transform.position = new
                    Vector3( xcoords[x2], ycoords[y2] - 8 );
            }

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool GetHex( int xpos, int ypos )
    {

        if ( grid[xpos, ypos] != null )
        {

            return true;

        }
        else{

            return false;

        }

    }

}
