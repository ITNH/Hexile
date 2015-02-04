using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    public int basespeed;
    public int dropspeed;

    public GameObject board;

    public GameObject[] hexels;

    private GameObject currenthexel;

    private System.Random random = new System.Random();

    [HideInInspector]
    public static int level;
    [HideInInspector]
    public static int speed;

    [HideInInspector]
    public static BoardController boardcontroller;
    [HideInInspector]
    public static ScoreController scorecontroller;
    
    void Start()
    {

        board = Instantiate(board, new
            Vector3(0, 0), Quaternion.identity) as GameObject;

        boardcontroller = transform.root.gameObject.GetComponent<BoardController>();
        scorecontroller = transform.root.gameObject.GetComponent<ScoreController>();

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

        // check if the hexel has set and self-destructed
        if (currenthexel == null)
        {

            // create a random new hexel
            currenthexel = Instantiate(hexels[random.Next(0, hexels.Length)], new
            Vector3(0, 0), Quaternion.identity) as GameObject;

            // trigger the score controller
            scorecontroller.Trigger();

        }
        
    }

}
