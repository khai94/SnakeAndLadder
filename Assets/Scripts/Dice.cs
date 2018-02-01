using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public int value;
	public int turn = 0;
	public int max;
	private bool isMoving = false;
	private bool turnEnds = false;
	public Piece currentPiece;

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
			gameUI.playerName.text = currentPiece.name;
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

			currentPiece = gameManager.playerList [turn];
			camera.target = currentPiece.transform;
			gameUI.playerName.text = currentPiece.name;
			turnEnds = false;
		}
	}

	public void RollDice(){
		if (!isMoving & !gameManager.GameIsOver) {
			turnEnds = false;
			isMoving = true;
			StartCoroutine (Move ());
		}
	}

	private IEnumerator Move() {
		value = Random.Range (1, 7);
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
		turnEnds = true;
		isMoving = false;
	}
}
