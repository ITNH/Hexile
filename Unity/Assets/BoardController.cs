using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

    public GameObject[] hexagons;

	void Start () {

        Instantiate( hexagons[0] );

	}

}
