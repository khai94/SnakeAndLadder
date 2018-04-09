using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISettings : MonoBehaviour {
	public Text playerName;
	public Text winnerName;
	public Image playerSpriteImage;
	public GameObject gameOverPanel;
	private GameSettings gameManager;

	// Use this for initialization
	void Start () {
		if (gameManager == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("GameController");
			gameManager = go.GetComponent<GameSettings> ();
		}
		gameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GameIsOver) {
			winnerName.text = gameManager.winner.name.ToString();
			gameOverPanel.SetActive (true);
		}
	}
}
