using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

        LoadData();
	}

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/audio.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/audio.dat", FileMode.Open);
            Data data = (Data)formatter.Deserialize(file);
            file.Close();

            //load some data
            musicPlayer.mute = data.musicIsOn;
        }
        else
        {
            Debug.Log("File does not exists!");
        }
    }
}
