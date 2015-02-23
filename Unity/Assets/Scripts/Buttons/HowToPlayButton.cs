using UnityEngine;

public class HowToPlayButton : MonoBehaviour
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

        Application.LoadLevel("HowToPlay");

    }

}
