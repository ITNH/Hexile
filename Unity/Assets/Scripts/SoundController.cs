using UnityEngine;

public class SoundController : MonoBehaviour {

    public void PlaySound(int sound)
    {

        audio.PlayOneShot(GameManager.sounds[sound]);

    }

}
