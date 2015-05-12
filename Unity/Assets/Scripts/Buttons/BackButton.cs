using UnityEngine;

public class BackButton : MonoBehaviour {

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

        GameManager.soundcontroller.PlaySound(6);

        Application.LoadLevel("MainMenu");

    }

}
