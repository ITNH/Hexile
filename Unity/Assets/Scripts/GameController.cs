using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    public int basespeed;
    public int dropspeed;

    public GameObject boardprefab;
    public GameObject[] hexelprefabs;

    private GameObject board;
    private GameObject currenthexel;

    private System.Random random = new System.Random();

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
            currenthexel = Instantiate(hexelprefabs[random.Next(0, hexelprefabs.Length)], new
            Vector3(0, 0), Quaternion.identity) as GameObject;

        }
        
    }

}
