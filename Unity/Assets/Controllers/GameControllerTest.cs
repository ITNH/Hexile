using UnityEngine;
using System.Collections;

public class GameControllerTest : MonoBehaviour {

    private BoardController board;
    
	void Start ()
    {

        board = (BoardController)GameObject.Find("Board").GetComponent<MonoBehaviour>();

	}

    void Update()
    {

        

    }

}
