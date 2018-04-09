using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCount : MonoBehaviour {

	public Dropdown dropdown;
	public GameObject[] playerArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPlayerCount()
	{
		int count = dropdown.value + 2;

		foreach (GameObject go in playerArray) {
			go.SetActive (false);
		}

		for (int i = 0; i < count; i++) {
			playerArray [i].SetActive (true);
		}
	}
}
