using UnityEngine;

public class NewGameButton : MonoBehaviour
{

    void OnMouseEnter()
    {

        gameObject.GetComponent<Renderer>().enabled = true;

        GameManager.soundcontroller.PlaySound(4);

    }

    void OnMouseExit()
    {

        gameObject.GetComponent<Renderer>().enabled = false;

    }

    void OnMouseDown()
    {

        GameManager.soundcontroller.PlaySound(3);

        Application.LoadLevel("Game");

        GameManager.gamecontroller.NewGame();

    }

}
