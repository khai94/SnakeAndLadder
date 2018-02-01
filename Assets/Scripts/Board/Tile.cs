using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

enum TileType {
	Normal,
	Snake,
	Ladder
};

public class Tile : MonoBehaviour, IComparable<Tile>{
	public TextMesh tileNumberText;

	private TileType type;
	public int tileNum;
	public int x, y;
	private bool isConnected = false;	// is the tile already connected to another Tile?
	private Tile connectedTile;			// store info of the connected Tile

	// Use this for initialization
	void Start () {
		tileNumberText.text = tileNum.ToString ();
	}

	public int CompareTo(Tile tile){
		if (tile == null) {
			return 1;
		} else {
			return this.tileNum.CompareTo (tile.tileNum);
		}
	}
}
