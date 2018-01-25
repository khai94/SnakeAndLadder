using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardSettings : MonoBehaviour {
	public GameObject tilePrefab;
	public List<Tile> tileList;
	public List<Piece> playerList;

	public int boardSize = 10;
	public bool GameIsOver = false;
	public Piece winner;
	private int tileSize = 10;

	void Awake () {
		tileList = new List<Tile> ();
		playerList = new List<Piece> ();
		SpawnBoard ();
	}

	void Start () {
		GameObject[] playerArray = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject go in playerArray) {
			playerList.Add (go.GetComponent<Piece> ());
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void SpawnBoard()
	{
		float x = transform.position.x;
		float y = transform.position.y;

		for (int i = 0; i < boardSize; i += tileSize) 
		{
			for (int j = 0; j < boardSize; j += tileSize) 
			{
				x = j;
				y = i;
				transform.position = new Vector3 (x, y, 0);
				GameObject go = Instantiate (tilePrefab, transform.position, transform.rotation, null) as GameObject;
				tileList.Add (go.GetComponent<Tile>());
			}
		}
	}
}
