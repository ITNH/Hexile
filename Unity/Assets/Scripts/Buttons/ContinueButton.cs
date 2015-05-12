using UnityEngine;

public class ContinueButton : MonoBehaviour
{

    void OnMouseEnter()
    {

        if (GameManager.savecontroller.IsGameSaved())
        {

            gameObject.GetComponent<Renderer>().enabled = true;

            GameManager.soundcontroller.PlaySound(4);

        }

    }

    void OnMouseExit()
    {

        gameObject.GetComponent<Renderer>().enabled = false;

    }

    void OnMouseDown()
    {

        GameManager.soundcontroller.PlaySound(3);

        if (GameManager.savecontroller.IsGameSaved())
        {

            Application.LoadLevel("Game");

            GameManager.gamecontroller.LoadGame();

        }

    }

}
