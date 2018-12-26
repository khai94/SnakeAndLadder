using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeButton : MonoBehaviour {
    private Theme theme;
    private Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        theme = GameObject.Find("ThemeManager").GetComponent<Theme>();

        button.onClick.AddListener(SetThemeColor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetThemeColor()
    {
        theme.themeColor = button.image.color;
    }
}
