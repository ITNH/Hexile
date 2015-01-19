using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int basespeed;
    public int dropspeed;

    [HideInInspector]
    public static int level;
    [HideInInspector]
    public static int speed;
    [HideInInspector]
    public static BoardController board;

    void Start()
    {

        board = (BoardController)GameObject.Find("Board").GetComponent<MonoBehaviour>();

        level = 1;
        speed = 59;

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
