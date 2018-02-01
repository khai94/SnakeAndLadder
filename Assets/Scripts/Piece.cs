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

	// Use this for initialization
	void Start () {
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
		
		CheckWinLoseCondition ();
	}

	public void UpdatePosition(){
		position = currentTile.tileNum;
		transform.position = new Vector3 (currentTile.gameObject.transform.position.x, currentTile.gameObject.transform.position.y, transform.position.z);
	}

	private void CheckWinLoseCondition(){
		if (currentTile == gameBoard.tileList [gameBoard.tileList.Count-1]) {
			gameManager.GameIsOver = true;
			gameManager.winner = this;
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
