using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour
{

    public GameObject board;
    public GameObject[] hexelprefabs;

    [HideInInspector]
    public static BoardController boardcontroller;
    [HideInInspector]
    public static ScoreController scorecontroller;
    [HideInInspector]
    public static GameObject currenthexel;

    private static System.Random random = new System.Random();
    private static GameObject[] hexels;
    
    void Start()
    {

        board = Instantiate(board, new
            Vector3(0, 0), Quaternion.identity) as GameObject;

        boardcontroller = transform.root.gameObject.GetComponent<BoardController>();
        scorecontroller = transform.root.gameObject.GetComponent<ScoreController>();

        hexels = hexelprefabs;

        SpawnHexel();

    }

    public static void DestroyHexel()
    {

        Destroy(currenthexel);
        currenthexel = null;

        scorecontroller.Trigger();

    }

    public static void SpawnHexel()
    {

        currenthexel = Instantiate(hexels[random.Next(0, hexels.Length)], new
            Vector3(0, 0), Quaternion.identity) as GameObject;

    }

}
