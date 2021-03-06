﻿using UnityEngine;
using System;

public enum TileType {
	Normal,
	Snake,
	Ladder,
	Game,
	Chance
};

public class Tile : MonoBehaviour, IComparable<Tile>{
	public TextMesh tileNumberText;
	public TileType type;
	public int tileNum;

	public Tile connectedTile;			// store info of the connected Tile
	public Tile head;					// the Head tile is where the snake/ladder trigger should occur
	public Chance chance;

	// Use this for initialization
	void Awake () {
		
		SetTileNumber ();

		ResetTileType ();
	}

	void SetTileNumber(){
		string tileNumberStr = gameObject.name.Substring (6);
		tileNumberStr = tileNumberStr.Remove (tileNumberStr.LastIndexOf(')'));

		int result;
		Int32.TryParse (tileNumberStr, out result);

		tileNum = result + 1;

		tileNumberText = GetComponentInChildren<TextMesh> ();
		tileNumberText.text = tileNum.ToString ();
	}

	public void ResetTileType(){
        tileNumberText = GetComponentInChildren<TextMesh>();
        switch (type) {
		    case TileType.Normal:
			    break;

		    case TileType.Ladder:
                tileNumberText.color = Color.green;
                connectedTile.type = TileType.Ladder;

			    if (connectedTile.connectedTile == null || connectedTile.connectedTile != this.GetComponent<Tile>()) {
				    connectedTile.connectedTile = this.GetComponent<Tile> ();
			    }
			    head = this.GetComponent<Tile>();

			    if (type == TileType.Ladder) {
				    // if connected tile's number is lower than this tile's number
				    if (tileNum > connectedTile.tileNum) {
					    connectedTile.head = this.GetComponent<Tile>();		// trigger is the lower of the two
					    head = null;										// the other tile doesn't have a head
				    }
			    }
			    break;

		    case TileType.Snake:
                tileNumberText.color = Color.red;
                connectedTile.type = TileType.Snake;

			    if (connectedTile.connectedTile == null || connectedTile.connectedTile != this.GetComponent<Tile>()) {
				    connectedTile.connectedTile = this.GetComponent<Tile> ();
			    }

			    head = this.GetComponent<Tile>();

			    if (type == TileType.Snake) {
				    // if connected tile's number is higher than this tile's number
				    if (tileNum < connectedTile.tileNum) {
					    connectedTile.head = this.GetComponent<Tile>();		// trigger is the higher of the two
					    head = null;										// the other tile doesn't have a head
				    }
			    }
			    break;

		    case TileType.Chance:
			    chance = gameObject.AddComponent (typeof(Chance)) as Chance;
			    break;

		    case TileType.Game:
			    break;

		    default:
			    break;
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
