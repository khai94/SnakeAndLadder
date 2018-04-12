using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Player
{
	public string name;
	public Sprite avatar;
	public bool isBot;
	public bool isActive;
}

public class DataManagement : MonoBehaviour {
	public List<Player> slotList;
	public PlayerCount playerCount;
	public static GameObject data;

	// Use this for initialization
	void Start () {
		if (data) {
			Destroy (this);
			Debug.Log ("Destroy");
		} else {
			data = GameObject.FindGameObjectWithTag ("DataManager");
			DontDestroyOnLoad (this);
			Debug.Log ("Don't destroy");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			SetPlayerSlot ();
		}
	}

	public void SetPlayerSlot()
	{
		slotList.Clear ();

		foreach (PlayerSlot player in playerCount.playerArray) {
			Player nPlayer;
			nPlayer.name = player.name;
			nPlayer.avatar = player.avatar;
			nPlayer.isBot = player.isBot;
			nPlayer.isActive = player.gameObject.activeSelf;

			slotList.Add (nPlayer);
		}

		slotList.ForEach (DisplayList);
	}

	private void DisplayList(Player player)
	{
		Debug.Log (player.name + ", " + player.isBot.ToString());
	}
}
