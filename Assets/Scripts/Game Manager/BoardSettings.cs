using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardSettings : MonoBehaviour {
	public GameObject tilePrefab;
	public List<Tile> tileList;
	public int boardSize = 10;
	private int tileSize = 10;

	// Use this for initialization
	void Start () {
		tileList = new List<Tile> ();
		SpawnBoard ();
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
