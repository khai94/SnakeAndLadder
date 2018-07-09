using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour {
    Audio audioManager;
    public Toggle musicToggle;
    public Toggle sfxToggle;
    int test;

	public void FindAudioManager()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }

    private void Awake()
    {
        FindAudioManager();
        LoadData();
    }

    private void Start()
    {  
        if (audioManager.musicPlayer.mute)
        {
            Debug.Log("volume is off");  
        }
        
        
    }

    public void ToggleMusic()
    {
        audioManager.musicPlayer.mute = !audioManager.musicPlayer.mute;
    }

    public void ToggleSFX()
    {
        if (!audioManager.sfxPlayer.mute)
        {
            audioManager.sfxPlayer.Stop();
        }
        else
        {
            audioManager.sfxPlayer.Play();
        }
    }

    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/audio.dat");

        Data data = new Data();

        // save some data
        data.musicIsOn = audioManager.musicPlayer.mute;
        data.musicToggleIsOn = musicToggle.isOn;

        formatter.Serialize(file, data);
        file.Close();
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
            musicToggle.isOn = data.musicToggleIsOn;
            audioManager.musicPlayer.mute = data.musicIsOn;
        }
        else
        {
            Debug.Log("File does not exists!");
        }
    }
}
