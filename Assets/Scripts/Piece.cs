using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {
	public Tile currentTile;
	public int position;
	private BoardSettings gameBoard;

	// Use this for initialization
	void Start () {
		if (gameBoard == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("GameController");
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
		Debug.Log (gameObject.ToString() + " position: " + position.ToString());
		transform.position = new Vector3 (currentTile.gameObject.transform.position.x, currentTile.gameObject.transform.position.y, transform.position.z);
	}

	private void CheckWinLoseCondition(){
		if (currentTile == gameBoard.tileList [gameBoard.tileList.Count-1]) {
			gameBoard.GameIsOver = true;
			gameBoard.winner = this;
		}
	}
}
