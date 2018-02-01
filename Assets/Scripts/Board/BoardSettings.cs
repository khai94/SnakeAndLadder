using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardSettings : MonoBehaviour {
	public List<Tile> tileList;

	void Awake () {
		tileList = new List<Tile> ();

		GameObject[] tileArray = GameObject.FindGameObjectsWithTag ("Tile");

		foreach (GameObject go in tileArray) {
			tileList.Add (go.GetComponent<Tile> ());
		}
		tileList.Sort ();
	}
}
