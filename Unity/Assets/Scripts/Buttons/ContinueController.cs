using UnityEngine;

public class ContinueController : MonoBehaviour {

	void Start()
    {

        if (GameManager.savecontroller.IsGameSaved())
        {

            gameObject.renderer.enabled = true;

        }

    }

}
