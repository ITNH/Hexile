using UnityEngine;
using System.Collections;


public class HexelController : MonoBehaviour
{

    // shape definitions
    // {x1,x2,x3,x4,y1,y2,y3,y4}
    public int[] Rotate0;
    public int[] Rotate60;
    public int[] Rotate120;
    public int[] Rotate180;
    public int[] Rotate240;
    public int[] Rotate300;

    public int color;
    public int xoffset;
    public int yoffset;

    private int counter;
    private int rotation;

    private GameObject[] hexes;

    private static BoardController board = GameController.board;

    void Start()
    {

        counter = 0;
        rotation = 0;

        for (int i = 0; i < 4; i++)
        {

            hexes[i] = Instantiate(board.hexagons[color], new
                Vector3(board.GetXCoord(Rotate0[i] + xoffset),
                board.GetYCoord(Rotate0[i] + xoffset, Rotate0[i + 4] + yoffset)),
                Quaternion.identity) as GameObject;

        }

    }

    void Update()
    {

        counter++;

        if (counter >= GameController.speed)
        {

            counter = 0;

            //TODO: Gravity checks

            if (yoffset > 0)
                yoffset--;

            for (int i = 0; i < 4; i++)
            {

                hexes[i].transform.position = new Vector3(board.GetXCoord(Rotate0[i] + xoffset),
                board.GetYCoord(Rotate0[i] + xoffset, Rotate0[i + 4] + yoffset));

            }

        }

        if (Input.GetButtonDown("Left") && !Input.GetButtonDown("Right"))
        {

            if (xoffset > 0)
                xoffset--;

            for (int i = 0; i < 4; i++)
            {

                hexes[i].transform.position = new Vector3(board.GetXCoord(Rotate0[i] + xoffset),
                board.GetYCoord(Rotate0[i] + xoffset, Rotate0[i + 4] + yoffset));

            }

        }

        if (Input.GetButtonDown("Right") && !Input.GetButtonDown("Left"))
        {

            if (xoffset < 15)
                xoffset++;

            for (int i = 0; i < 4; i++)
            {

                hexes[i].transform.position = new Vector3(board.GetXCoord(Rotate0[i] + xoffset),
                board.GetYCoord(Rotate0[i] + xoffset, Rotate0[i + 4] + yoffset));

            }

        }

    }

}
