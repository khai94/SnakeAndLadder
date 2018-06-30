using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour {
    Audio audioManager;

	public void FindAudioManager()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }

    public void ToggleMusic()
    {
        if (audioManager.musicPlayer.isPlaying)
        {
            audioManager.musicPlayer.Stop();
        }
        else
        {
            audioManager.musicPlayer.Play();
        }
    }

    public void ToggleSFX()
    {
        if (audioManager.sfxPlayer.isPlaying)
        {
            audioManager.sfxPlayer.Stop();
        }
        else
        {
            audioManager.sfxPlayer.Play();
        }
    }
}
