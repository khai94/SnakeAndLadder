using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;
    public static GameObject audioManager;
    public AudioClip[] musicTracks;
    public AudioClip[] soundEffects;

    // Use this for initialization
    void Start () {
		if(audioManager)
        {
            Destroy(this.gameObject);
       
        }
        else
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio");
            DontDestroyOnLoad(this.gameObject);
        }
	}
}
