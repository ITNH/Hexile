using UnityEngine;

public class NewGameButton : MonoBehaviour {

    void OnMouseEnter()
    {

        gameObject.renderer.enabled = true;

    }

    void OnMouseExit()
    {

        gameObject.renderer.enabled = false;

    }

    void OnMouseDown()
    {

        Application.LoadLevel("Game");

        GameManager.gamecontroller.NewGame();

    }

}
