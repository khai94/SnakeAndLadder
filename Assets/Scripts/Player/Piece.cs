using UnityEngine;
using System;

public enum Status
{
	Normal,
	Stunned,
	Slow,
	Drain,
    Confused
}

public class Piece : MonoBehaviour, IComparable<Piece> {
	
	public Tile currentTile;
	public bool isBot;
	public int position;
	public int turnOrder;
	public int statusDuration = 0;
	public int coin;
    public int moveModifier = 0;
	public string username;
	public Sprite avatar;
	public Status status = Status.Normal;

	public SpriteRenderer spr;

	private GameSettings gameManager;
	private BoardSettings gameBoard;


	// Use this for initialization
	void Start () {
		spr = gameObject.GetComponent<SpriteRenderer>();

		if (gameManager == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("GameController");
			gameManager = go.GetComponent<GameSettings> ();
			spr.sprite = avatar;
		}

		if (gameBoard == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Board");
			gameBoard = go.GetComponent<BoardSettings> ();
		}

		if (currentTile == null) {
			currentTile = gameBoard.tileList[0];
		}
	}

	public void UpdatePosition() {
		this.transform.position = currentTile.transform.position;
		position = currentTile.tileNum - 1;
	}

	public void UpdatePosition(int n) {
		Vector3 target = gameBoard.tileList [n].transform.position;

		this.transform.position = target;

		currentTile = gameBoard.tileList [n];
	}

	public int CompareTo(Piece piece){
		if (piece == null) {
			return 1;
		} else {
			return this.turnOrder.CompareTo (piece.turnOrder);
		}
	}


}
