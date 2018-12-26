using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Theme : MonoBehaviour {
    public Color themeColor;
    public Color textColor;
    public Color buttonColor;

    public static Theme instance;

	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update () {
		
	}

    // load theme
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/theme.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/theme.dat", FileMode.Open);
            Data data = (Data)formatter.Deserialize(file);
            file.Close();

            //load some data
            //themeColor = data.themeColor;
            themeColor.r = data.r;
            themeColor.g = data.g;
            themeColor.b = data.b;
            themeColor.a = data.a;
        }
        else
        {
            Debug.Log("File does not exists!");
        }
    }

    // save theme
    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/theme.dat");

        Data data = new Data();

        // save some data
        //data.themeColor = themeColor;
        data.r = themeColor.r;
        data.g = themeColor.g;
        data.b = themeColor.b;
        data.a = themeColor.a;

        formatter.Serialize(file, data);
        file.Close();
    }
}
