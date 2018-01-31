using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISettings : MonoBehaviour {
	public Text playerName;
	public Text winnerName;
	public Image playerSpriteImage;
	public GameObject gameOverPanel;
	private BoardSettings gameBoard;

	// Use this for initialization
	void Start () {
		if (gameBoard == null) {
			GameObject go = GameObject.Find ("GameManager");
			gameBoard = go.GetComponent<BoardSettings> ();
		}
		gameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameBoard.GameIsOver) {
			winnerName.text = playerName.text;
			gameOverPanel.SetActive (true);
		}
	}
}
