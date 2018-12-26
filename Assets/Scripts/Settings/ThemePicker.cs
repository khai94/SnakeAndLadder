using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemePicker : MonoBehaviour {
    Theme theme;
    Image image;

	// Use this for initialization
	void Start () {
        if(theme == null)
            theme = GameObject.Find("ThemeManager").GetComponent<Theme>();
        image = gameObject.GetComponent<Image>();

        image.color = theme.themeColor;
	}
	
	// Update is called once per frame
	void Update () {
        image.color = theme.themeColor;
    }

    
}
