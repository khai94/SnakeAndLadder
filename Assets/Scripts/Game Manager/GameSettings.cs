using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSettings : MonoBehaviour {
	public List<Piece> playerList;

	public bool GameIsOver = false;
	public Piece winner;

	void Awake () {
		playerList = new List<Piece> ();
	}

	void Start () {
		GameObject[] playerArray = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject go in playerArray) {
			playerList.Add (go.GetComponent<Piece> ());
		}

		playerList.Sort ();
	}

}
