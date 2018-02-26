using UnityEngine;
using System;
using System.Collections;

public class Piece : MonoBehaviour, IComparable<Piece> {
	public Tile currentTile;
	public int position;
	public int turnOrder;
	public string name;
	private GameSettings gameManager;
	private BoardSettings gameBoard;
	public SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		spr = gameObject.GetComponent<SpriteRenderer>();

		if (gameManager == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("GameController");
			gameManager = go.GetComponent<GameSettings> ();
		}

		if (gameBoard == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Board");
			gameBoard = go.GetComponent<BoardSettings> ();
		}

		if (currentTile == null) {
			currentTile = gameBoard.tileList[0];
			UpdatePosition ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//CheckWinLoseCondition ();
	}

	public void UpdatePosition(){
		position = currentTile.tileNum;
		transform.position = new Vector3 (
			currentTile.gameObject.transform.position.x, 
			currentTile.gameObject.transform.position.y, 
			transform.position.z
		);

		if (transform.position.x > gameBoard.tileList [position].transform.position.x) {
			spr.flipX = true;
		} else if (transform.position.x < gameBoard.tileList [position].transform.position.x) {
			spr.flipX = false;
		}
	}
		
	public int CompareTo(Piece piece){
		if (piece == null) {
			return 1;
		} else {
			return this.turnOrder.CompareTo (piece.turnOrder);
		}
	}
}
