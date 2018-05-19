using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
	Forward, 
	Backward, 
	Stun, 
	Teleport, 
	Treasure,
	Confuse,
	Slow,
	Drain
}

public class Chance : MonoBehaviour {
	public string title;
	public string description;
	public Effect effect;

	private MovePiece move;
	private UISettings gameUI;

	void Start ()
	{
		gameUI = GameObject.Find ("UIManager").GetComponent<UISettings> ();
	}

	public void GetMovement(MovePiece movement)
	{
		move = movement;
	}

	public void ExecuteEffect(int i)
	{
		gameUI.eventPanel.gameObject.SetActive (true);
		gameUI.eventTitleText.text = "CHANCE!";

		effect = (Effect) i;

		switch (effect) {
		case Effect.Backward:
			move.MoveAmount (Random.Range (-4, -1));
			gameUI.eventDescText.text = "You are pushed back a few tiles away!";
			break;
		
		case Effect.Forward:
			move.MoveAmount (Random.Range (1, 4));
			gameUI.eventDescText.text = "You jumped a few tiles ahead!";
			break;
		
		case Effect.Stun:
			move.currentPiece.status = Status.Stunned;
			move.currentPiece.statusDuration = Random.Range (2, 4);
			gameUI.eventDescText.text = "You are stunned for a few turns!";
			break;

		case Effect.Teleport:
			int target;
			do {
				target = Random.Range (10, 80);
			} while (target == move.currentPiece.position);

			move.currentPiece.position = target;
			move.currentPiece.UpdatePosition (target);
			gameUI.eventDescText.text = "You are magically teleported to a new location!";
			break;

		case Effect.Treasure:
			int value = Random.Range (1, 6) * 100;
			move.currentPiece.coin += value;
			gameUI.eventDescText.text = "You found some hidden treasure!";
			break;

			// confuse

			// slow

			// drain coins
		}
	}
}
