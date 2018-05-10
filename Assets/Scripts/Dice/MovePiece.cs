using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePiece : MonoBehaviour {
	public int turn = 0;
	public int max;

	public bool isMoving = false;
	public bool isMoved = false;
	public bool turnEnds = false;

	public Piece currentPiece;
	public Button diceButton;
	public Button endTurnButton;
	public Dice dice;

	private GameSettings gameManager;
	private BoardSettings gameBoard;
	private UISettings gameUI;
	private CameraView camera;

	// Use this for initialization
	void Awake () {
		GameObject go = GameObject.FindGameObjectWithTag ("GameController");
		gameManager = go.GetComponent<GameSettings> ();
		max = gameManager.playerList.Count - 1;
		go = GameObject.FindGameObjectWithTag ("Board");
		gameBoard = go.GetComponent<BoardSettings> ();
		go = GameObject.Find ("UIManager");
		gameUI = go.GetComponent<UISettings> ();
		camera = Camera.main.gameObject.GetComponent<CameraView> ();
	}

	void Start () {
		if (currentPiece.isBot) {
			BotMove ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (gameUI.playerName.name != currentPiece.name) {
			UpdatePlayerInfo ();
		}

		if (currentPiece.isBot && isMoved) {
			EndTurn ();
		}

		if (turnEnds && !gameManager.GameIsOver) {
			if (turn < max) {
				++turn;
			} else {
				turn = 0;
			}

			currentPiece.spr.sortingOrder = 0;
			currentPiece = gameManager.playerList [turn];
			currentPiece.spr.sortingOrder = 1;

			WaitForStun ();

			camera.target = currentPiece.transform;
			//UpdatePlayerInfo ();

			diceButton.interactable = true;
			turnEnds = false;

			if (currentPiece.isBot) {
				BotMove ();
			}
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
		if (currentPiece.status == Status.Stunned) {
			//WaitForStun ();
			Debug.Log ("Still stunned");
		} else {
			endTurnButton.interactable = false;

			int target = currentPiece.position;

			// randomize dice face sprite before actually getting the value to get the "rolling" effect.
			for (int i = 0; i < 5; i++) {
				dice.value = Random.Range (1, 7);
				diceButton.image.sprite = dice.diceFaces [dice.value - 1];
				yield return new WaitForSeconds (0.2f);
			}

			for (int i = 0; i < dice.value; i++) {
				if (gameManager.GameIsOver)
					break;

				currentPiece.position++;
				target++;
				//Debug.Log (currentPiece.ToString() + "| Target: " + target);

				if (GoalReached (target)) {
					target = 99;
				}

				currentPiece.UpdatePosition (target);
				camera.FollowTarget ();
				yield return new WaitForSeconds (1f);
			}
			CheckForEvent ();
		}

		isMoved = true;
		isMoving = false;
		endTurnButton.interactable = true;
	}

	public void MoveAmount(int steps)
	{
		currentPiece.position += steps;

		if (GoalReached (currentPiece.position)) {
			currentPiece.position = 99;
		}
		if (currentPiece.position < 0) {
			currentPiece.position = 0;
		}

		currentPiece.UpdatePosition (currentPiece.position);
		camera.FollowTarget ();
	}

	private void CheckForEvent() {
		// check win/lose condition
		if (currentPiece.currentTile == gameBoard.tileList [gameBoard.tileList.Count-1]) {
			gameManager.GameIsOver = true;
			gameManager.winner = currentPiece;
			Debug.Log ("Winner: " + gameManager.winner);
			return;
		}

		if (currentPiece.currentTile.head != null) {
			if (currentPiece.currentTile.head.type == TileType.Snake || currentPiece.currentTile.head.type == TileType.Ladder) {
				Debug.Log ("Ladder/Snake");
				currentPiece.currentTile = currentPiece.currentTile.connectedTile;
				currentPiece.UpdatePosition ();
			}
			return;
		} else {
			if (currentPiece.currentTile.type == TileType.Chance) {
				Debug.Log ("Chance");

				if (currentPiece.currentTile.chance == null) {
					return;
				}

				Chance chance = currentPiece.currentTile.GetComponent<Chance> ();
				int effect = Random.Range (0, (int)Effect.treasure + 1);
				//Debug.Log (effect.ToString());
				chance.GetMovement (this);
				chance.ExecuteEffect (effect);
			}
		}
	}
		
	public void EndTurn() {
		if (isMoved || currentPiece.status == Status.Stunned) {
			WaitForStun ();

			isMoved = false;
			turnEnds = true;
		}

		/*
		if (currentPiece.status == Status.Stunned) {
			WaitForStun ();
		}
		*/
	}

	private void UpdatePlayerInfo() {
		gameUI.playerName.text = currentPiece.name;
		gameUI.playerSpriteImage.sprite = currentPiece.spr.sprite;
	}

	private void BotMove() {
		RollDice ();
	}

	private bool GoalReached(int pos)
	{
		if (pos > 99) {
			return true;
		} else
			return false;
	}

	private void WaitForStun()
	{
		currentPiece.statusDuration--;
		if (currentPiece.statusDuration < 0) {
			currentPiece.statusDuration = 0;
			currentPiece.status = Status.Normal;
		} else {
			return;
		}
	}
}
