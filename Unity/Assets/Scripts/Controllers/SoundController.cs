using UnityEngine;

public class SoundController : MonoBehaviour {

    public void PlaySound(int sound)
    {

        GetComponent<AudioSource>().PlayOneShot(GameManager.sounds[sound]);

    }

}
