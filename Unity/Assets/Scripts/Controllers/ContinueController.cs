using UnityEngine;

public class ContinueController : MonoBehaviour {

	void Start()
    {

        if (GameManager.savecontroller.IsGameSaved())
        {

            gameObject.GetComponent<Renderer>().enabled = true;

        }

    }

}
