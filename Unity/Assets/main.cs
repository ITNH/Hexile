using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    BoardController board; 
    
	void Start () {

        board = (BoardController)GameObject.Find("background").GetComponent<MonoBehaviour>();
        board.AddHex(0, 0, 0);
        board.AddHex(1, 0, 0);
        board.AddHex(1, 1, 0);
        board.AddHex(2, 0, 0);

	}

}
