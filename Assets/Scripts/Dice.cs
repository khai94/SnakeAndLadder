using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dice : MonoBehaviour {
	public int value;
	public int turn = 0;
	public int max;
	private bool isMoving = false;
	private bool isMoved = false;
	private bool turnEnds = false;
	public Piece currentPiece;
	public Button diceButton;
	public Button endTurnButton;

	private GameSettings gameManager;
	private BoardSettings gameBoard;
	private UISettings gameUI;
	private CameraView camera;

	// Use this for initialization
	void Start () {
		if (gameManager == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("GameController");
			gameManager = go.GetComponent<GameSettings> ();
			max = gameManager.playerList.Count - 1;
		}

		if (gameBoard == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Board");
			gameBoard = go.GetComponent<BoardSettings> ();
		}

		if (gameUI == null) {
			GameObject go = GameObject.Find ("UIManager");
			gameUI = go.GetComponent<UISettings> ();
			UpdatePlayerInfo ();
		}

		if (camera == null) {
			camera = Camera.main.gameObject.GetComponent<CameraView> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (turnEnds) {
			if (turn < max) {
				++turn;
			} else {
				turn = 0;
			}

			currentPiece.spr.sortingOrder = 0;
			currentPiece = gameManager.playerList [turn];
			currentPiece.spr.sortingOrder = 1;

			camera.target = currentPiece.transform;
			UpdatePlayerInfo ();

			diceButton.interactable = true;
			turnEnds = false;
		}
	}

	public void RollDice(){
		if (!isMoving && !gameManager.GameIsOver && !isMoved) {
			turnEnds = false;
			isMoving = true;
			StartCoroutine (Move ());
		}
	}

	private IEnumerator Move() {
		endTurnButton.interactable = false;

		for (int i = 0; i < 5; i++) {
			value = Random.Range (1, 7);
			yield return new WaitForSeconds (0.2f);
		}

		for (int i = 0; i < value; i++) {
			if (gameManager.GameIsOver)
				break;
			
			currentPiece.position++;

			if (currentPiece.position > 100) {
				currentPiece.position = 100;
			}

			currentPiece.currentTile = gameBoard.tileList [currentPiece.position-1];
			currentPiece.UpdatePosition ();
			yield return new WaitForSeconds(0.5f);
		}
		CheckForEvent ();
		isMoved = true;
		isMoving = false;
		endTurnButton.interactable = true;
	}

	private void CheckForEvent() {
		// check win/lose condition
		if (currentPiece.currentTile == gameBoard.tileList [gameBoard.tileList.Count-1]) {
			gameManager.GameIsOver = true;
			gameManager.winner = currentPiece;
			return;
		}

		if (currentPiece.currentTile.head == null) {
			//Debug.Log ("Normal tile");
			return;
		}

		// check tile type effects
		if (currentPiece.currentTile.head.type == TileType.Snake || currentPiece.currentTile.head.type == TileType.Ladder) {
			currentPiece.currentTile = currentPiece.currentTile.connectedTile;
			currentPiece.UpdatePosition ();
		}
	}

	private void UpdatePlayerInfo(){
		gameUI.playerName.text = currentPiece.name;
		gameUI.playerSpriteImage.sprite = currentPiece.spr.sprite;
	}

	public void EndTurn(){
		isMoved = false;
		turnEnds = true;
	}
}
