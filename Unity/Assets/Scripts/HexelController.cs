using UnityEngine;
using System.Collections;

public class HexelController : MonoBehaviour
{

    public int[] Rotate0;
    public int[] Rotate180;

    public int color;
    public int speed;

    private int counter;

    private BoardController board;

    void Start()
    {

        board = (BoardController)GameObject.Find("Board").GetComponent<MonoBehaviour>();

        counter = 0;

        for (int i = 0; i < 8; i = i + 2)
        {

            board.AddHex(Rotate0[1], Rotate0[2], color);

        }

    }

    void Update()
    {

        counter++;

        if (counter == speed)
        {

            counter = 0;

            for (int i = 0; i < 8; i = i + 1)
            {

                

            }

        }

    }

}
