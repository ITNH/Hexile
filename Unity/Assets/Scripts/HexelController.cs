using UnityEngine;
using System.Collections;

public class HexelController : MonoBehaviour
{

    public int[] Rotate0;
    public int[] Rotate60;
    public int[] Rotate120;
    public int[] Rotate180;
    public int[] Rotate240;
    public int[] Rotate300;

    public int color;
    public int xoffset;
    public int yoffset;

    public int counter;
    private int rotation;

    void Start()
    {

        counter = 0;
        rotation = 0;

        for (int i = 0; i < 8; i = i + 2)
        {

            GameController.board.AddHex(Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset, color);

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

            for (int i = 0; i < 8; i = i + 2)
            {

                GameController.board.MoveHex(Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset + 1,
                    Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset);

            }

        }

        if (Input.GetButtonDown("Left") && !Input.GetButtonDown("Right"))
        {

            if (xoffset > 0)
                xoffset--;

            for (int i = 0; i < 8; i = i + 2)
            {

                GameController.board.MoveHex(Rotate0[i] + xoffset + 1, Rotate0[i + 1] + yoffset,
                    Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset);

            }

        }

        if (Input.GetButtonDown("Right") && !Input.GetButtonDown("Left"))
        {

            if (xoffset < 15)
                xoffset++;

            for (int i = 0; i < 8; i = i + 2)
            {

                GameController.board.MoveHex(Rotate0[i] + xoffset - 1, Rotate0[i + 1] + yoffset,
                    Rotate0[i] + xoffset, Rotate0[i + 1] + yoffset);

            }

        }

    }

}
