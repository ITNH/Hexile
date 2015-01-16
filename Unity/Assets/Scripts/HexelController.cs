using UnityEngine;
using System.Collections;

public class HexelController : MonoBehaviour
{

    public int[] Rotate0;
    public int[] Rotate180;

    public int color;
    public int speed;
    public int xoffset;
    public int yoffset;

    public int counter;

    private BoardController board;

    void Start()
    {

        board = (BoardController)GameObject.Find("Board").GetComponent<MonoBehaviour>();

        counter = 0;

        for (int i = 0; i < 8; i = i + 2)
        {

            board.AddHex(Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset, color);

        }

    }

    void Update()
    {

        counter++;

        if (counter == speed)
        {

            counter = 0;

            //TODO: Gravity checks

            if (yoffset > 0)
                yoffset--;

            for (int i = 0; i < 8; i = i + 2)
            {

                board.MoveHex(Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset + 1,
                    Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset);

            }

        }

    }

}
