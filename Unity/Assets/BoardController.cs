using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

    int[] xcoords = new int[] { 1, 15, 29, 43, 57, 71, 85, 99, 113, 127, 141, 155, 169, 183, 197, };
    int[] ycoords = new int[] { 9, 25, 41, 57, 73, 89, 105, 121, 137, 153, 169, 185, 201, 217, 233, };

    static Object[,] grid = new Object[15, 15];
    public GameObject[] hexagons;

	public bool AddHex ( int xpos, int ypos, int color ) {

        if ( grid[ xpos, ypos ] == null )
        {

            if (xpos % 2 == 0)
            {
                grid[xpos, ypos] = Instantiate(hexagons[color], new
                    Vector3( xcoords[xpos], ycoords[ypos] ),
                    Quaternion.identity);
            }
            else
            {
                grid[xpos, ypos] = Instantiate(hexagons[color], new
                    Vector3( xcoords[xpos], ycoords[ypos] - 8 ),
                    Quaternion.identity);
            }

            return true;

        }
        else
        {

            return false;

        }

	}

}
