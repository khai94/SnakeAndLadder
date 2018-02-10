using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum TileType {
	Normal,
	Snake,
	Ladder
};

public class Tile : MonoBehaviour, IComparable<Tile>{
	private TextMesh tileNumberText;
	public TileType type;
	public int tileNum;
	//public int x, y;
	//private bool isConnected = false;	// is the tile already connected to another Tile?
	public Tile connectedTile;			// store info of the connected Tile
	public Tile head;					// the Head tile is where the snake/ladder trigger should occur

	// Use this for initialization
	void Start () {
		tileNumberText = GetComponentInChildren<TextMesh> ();
		tileNumberText.text = tileNum.ToString ();

		if (type != TileType.Normal) {

			if (connectedTile.connectedTile == null || connectedTile.connectedTile != this.GetComponent<Tile>()) {
				connectedTile.connectedTile = this.GetComponent<Tile> ();
			}

			head = this.GetComponent<Tile>();

			if (type == TileType.Snake) {
				if (tileNum < connectedTile.tileNum) {
					connectedTile.head = this.GetComponent<Tile>();		// trigger is the higher of the two
					head = null;								// the other tile doesn't have a head
				}
			}

			if (type == TileType.Ladder) {
				if (tileNum > connectedTile.tileNum) {
					connectedTile.head = this.GetComponent<Tile>();		// trigger is the lower of the two
					head = null;										// the other tile doesn't have a head
				}
			}
		}
	}

	public int CompareTo(Tile tile){
		if (tile == null) {
			return 1;
		} else {
			return this.tileNum.CompareTo (tile.tileNum);
		}
	}
}
