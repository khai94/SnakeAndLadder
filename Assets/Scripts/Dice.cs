using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public int value;
	public int turn = 0;
	public int max;
	public Piece currentPiece;
	private BoardSettings gameBoard;

	// Use this for initialization
	void Start () {
		if (gameBoard == null) {
			GameObject go = GameObject.Find ("GameManager");
			gameBoard = go.GetComponent<BoardSettings> ();
			max = gameBoard.playerList.Count - 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RollDice(){
		value = Random.Range (1, 7);
		currentPiece.position += value;

		if (currentPiece.position > 100) {
			currentPiece.position = 100;
		}

		currentPiece.currentTile = gameBoard.tileList [currentPiece.position-1];
		currentPiece.UpdatePosition ();

		if (turn < max) {
			turn++;
		} else {
			turn = 0;
		}

		currentPiece = gameBoard.playerList [turn];
	}
}
