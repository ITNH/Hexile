using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int level;

    private bool triggerflag = false;
    private bool dropflag = false;
    private int dropcount;

    void Start()
    {

        score = 0;
        level = 1;

    }

    void Update()
    {

        if (triggerflag == true)
        {

            triggerflag = false;
            GameController.SpawnHexel();

        }

    }

    // Called when a hexel sets
    public void Trigger() 
    {

        triggerflag = true;
        
    }

}
