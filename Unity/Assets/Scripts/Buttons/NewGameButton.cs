using UnityEngine;

public class NewGameButton : MonoBehaviour
{

    /*
    void OnMouseEnter()
    {

        gameObject.renderer.enabled = true;

    }

    void OnMouseExit()
    {

        gameObject.renderer.enabled = false;

    }
    */

    void OnMouseDown()
    {

        GameManager.soundcontroller.PlaySound(3);

        Application.LoadLevel("Game");

        GameManager.gamecontroller.NewGame();

    }

}
