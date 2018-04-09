using UnityEngine;
using System;
using System.Collections;

public class Piece : MonoBehaviour, IComparable<Piece> {
	
	public Tile currentTile;
	public bool isBot;
	public int position;
	public int turnOrder;
	public string name;

	public SpriteRenderer spr;

	private GameSettings gameManager;
	private BoardSettings gameBoard;


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
			//UpdatePosition ();
		}
	}


	// Update is called once per frame
	void Update () {
		
		//CheckWinLoseCondition ();
	}

	public void UpdatePosition() {
		this.transform.position = currentTile.transform.position;
		position = currentTile.tileNum - 1;
	}

	public void UpdatePosition(int n) {
		Vector3 target = gameBoard.tileList [n].transform.position;

		//Vector3 direction = target - this.transform.position;

		if (transform.position.x > target.x && target.x != 0) {
			spr.flipX = true;
		} else if (transform.position.x < target.x) {
			spr.flipX = false;
		}

		this.transform.position = target;

		currentTile = gameBoard.tileList [n];
		//position = currentTile.tileNum;
	}

	public int CompareTo(Piece piece){
		if (piece == null) {
			return 1;
		} else {
			return this.turnOrder.CompareTo (piece.turnOrder);
		}
	}


}
