using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
	forward, backward, stun, teleport, treasure
}

public class Chance : MonoBehaviour {
	public string name;
	public string description;
	public Effect effect;

	private MovePiece move;

	public void GetMovement(MovePiece movement)
	{
		move = movement;
	}

	public void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.backward:
			move.MoveAmount (Random.Range (-4, -1));
			Debug.Log ("Moved backward");
			break;
		
		case Effect.forward:
			move.MoveAmount (Random.Range (1, 4));
			Debug.Log ("Moved forward");
			break;
		
		case Effect.stun:
			move.currentPiece.status = Status.Stunned;
			move.currentPiece.statusDuration = Random.Range (2, 4);
			Debug.Log ("Stunned for " + move.currentPiece.statusDuration + " turns.");
			break;

		case Effect.teleport:
			int target;
			do {
				target = Random.Range (10, 80);
			} while (target != move.currentPiece.position);

			move.currentPiece.position = target;
			move.currentPiece.UpdatePosition (target);
			Debug.Log ("Teleported to tile " + move.currentPiece.position);
			break;

		case Effect.treasure:
			int value = Random.Range (1, 6) * 100;
			Debug.Log ("Found " + value.ToString() + " coins.");
			break;
		}
	}
}
