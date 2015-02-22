using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

    private AudioSource intro;
    private AudioSource loop;

	void Start () {
	
        AudioSource[] sources = gameObject.GetComponents<AudioSource>();

        intro = sources[0];
        loop = sources[1];

    }
	
	void Update () {

        if (!intro.isPlaying && !loop.isPlaying)
        {

            loop.Play();

        }
	
	}
}
