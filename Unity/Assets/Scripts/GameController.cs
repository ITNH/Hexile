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

    private int width = 640;
    private int height = 480;
    
    void Start()
    {

        if (!Screen.fullScreen)
        {

            width = Screen.width;
            height = Screen.height;

        }

        board = Instantiate(board, new
            Vector3(0, 0), Quaternion.identity) as GameObject;

        boardcontroller = transform.root.gameObject.GetComponent<BoardController>();
        scorecontroller = transform.root.gameObject.GetComponent<ScoreController>();

        hexels = hexelprefabs;

        SpawnHexel();

    }

    void Update()
    {

        if (Input.GetButton("Back"))
        {

            Application.Quit();

        }



        if (Input.GetButtonDown("Fullscreen") && Screen.fullScreen)
        {

            Screen.SetResolution(width, height, false);

        }

        if (Input.GetButtonDown("Fullscreen") && !Screen.fullScreen)
        {

            width = Screen.width;
            height = Screen.height;
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

        }

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
