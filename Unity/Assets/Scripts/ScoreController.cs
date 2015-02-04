using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

    [HideInInspector]
    public int score;

    // Called when a hexel sets
    public void Trigger() 
    {

        Debug.Log("Whee!");
        
    }

}
