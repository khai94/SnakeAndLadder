using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public int value;
	public Piece piece;
	private BoardSettings gameBoard;

	// Use this for initialization
	void Start () {
		if (gameBoard == null) {
			GameObject go = GameObject.Find ("GameManager");
			gameBoard = go.GetComponent<BoardSettings> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RollDice(){
		value = Random.Range (1, 7);
		piece.position += value;

		if (piece.position > 100) {
			piece.position = 100;
		}

		piece.currentTile = gameBoard.tileList [piece.position-1];
		piece.UpdatePosition ();
	}
}
