using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCount : MonoBehaviour {

	public Dropdown dropdown;
	public PlayerSlot[] playerArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPlayerCount()
	{
		int count = dropdown.value + 2;

		foreach (PlayerSlot slot in playerArray) {
			slot.gameObject.SetActive (false);
		}

		for (int i = 0; i < count; i++) {
			playerArray [i].gameObject.SetActive (true);
		}
	}
}
