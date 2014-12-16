using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    BoardController board;

    private int counter;
    
	void Start ()
    {

        board = (BoardController)GameObject.Find("background").GetComponent<MonoBehaviour>();
        board.AddHex(0, 0, 0);

        counter = 0;

	}

    void Update()
    {

        counter++;

        if ( counter == 60 )
        {

            board.MoveHex(0, 0, 1, 1);

        }

    }

}
