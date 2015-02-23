using UnityEngine;

public class BackButton : MonoBehaviour {

    void OnMouseEnter()
    {

        gameObject.renderer.enabled = true;

        GameManager.soundcontroller.PlaySound(4);

    }

    void OnMouseExit()
    {

        gameObject.renderer.enabled = false;

    }

    void OnMouseDown()
    {

        GameManager.soundcontroller.PlaySound(3);

        Application.LoadLevel("MainMenu");

    }

}
