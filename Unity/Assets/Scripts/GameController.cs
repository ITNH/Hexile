using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int basespeed;
    public int dropspeed;

    public GameObject boardprefab;
    public GameObject[] hexelprefabs;

    private GameObject board;

    [HideInInspector]
    public static int level;
    [HideInInspector]
    public static int speed;
    [HideInInspector]
    public static BoardController boardcontroller;
    
    void Start()
    {

        board = Instantiate(boardprefab, new
            Vector3(0, 0), Quaternion.identity) as GameObject;

        boardcontroller = board.GetComponent<BoardController>();

        boardcontroller.AddHex(7, 0, 0);

        GameObject derp = Instantiate(hexelprefabs[0], new
            Vector3(0, 0), Quaternion.identity) as GameObject;


        level = 1;
        speed = basespeed - 1;

    }

    void Update()
    {

        if (Input.GetButton("Down")) {

            speed = dropspeed;

        }
        else
        {

            speed = basespeed - level;

        }
        
    }
}
