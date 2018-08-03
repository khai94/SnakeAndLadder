using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSettings : MonoBehaviour {
	public List<Piece> playerList;

	public bool GameIsOver = false;
	public Piece winner;
	private DataManagement data;
    public static Audio audioManager;

	void Awake () {
		playerList = new List<Piece> ();

		GameObject[] playerArray = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject go in playerArray) {
			playerList.Add (go.GetComponent<Piece> ());
		}

		playerList.Sort ();

		data = GameObject.FindGameObjectWithTag ("DataManager").GetComponent<DataManagement> ();

		for (int i = 0; i < playerList.Count; i++) {
			playerList [i].username = data.slotList [i].name;
			playerList [i].avatar = data.slotList [i].avatar;
			playerList [i].isBot = data.slotList [i].isBot;
			playerList [i].gameObject.SetActive(data.slotList [i].isActive);
		}

		for (int i = playerList.Count - 1; i >= 0; i--) {
			if (!playerList [i].gameObject.activeSelf) {
				playerList.Remove (playerList [i]);
			}
		}
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
	}

	void Start () {
        audioManager.PlayMusic(1);
        //audioManager.musicPlayer.clip = audioManager.musicTracks[1];
        //audioManager.musicPlayer.Play();
    }

}
