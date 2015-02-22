using UnityEngine;
using System.Collections;

// Controller responsible for operating the main menu
public class MenuController : MonoBehaviour {

	void Update () {

        if (Input.GetButtonDown("Select"))
        {

            GameManager.gamemanager.PlaySound(3);

            Application.LoadLevel("Game");

            GameManager.gamecontroller.NewGame();

        }
	
	}

}
