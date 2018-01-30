﻿using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public int value;
	public int turn = 0;
	public int max;
	private bool isMoving = false;
	private bool turnEnds = false;
	public Piece currentPiece;
	private BoardSettings gameBoard;
	private CameraView camera;

	// Use this for initialization
	void Start () {
		if (gameBoard == null) {
			GameObject go = GameObject.Find ("GameManager");
			gameBoard = go.GetComponent<BoardSettings> ();
			max = gameBoard.playerList.Count - 1;
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

			currentPiece = gameBoard.playerList [turn];
			camera.target = currentPiece.transform;
			turnEnds = false;
		}
	}

	public void RollDice(){
		if (!isMoving) {
			turnEnds = false;
			isMoving = true;
			StartCoroutine (Move ());
		}
	}

	private IEnumerator Move() {
		value = Random.Range (1, 7);
		for (int i = 0; i < value; i++) {
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
