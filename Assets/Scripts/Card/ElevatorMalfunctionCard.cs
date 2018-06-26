using UnityEngine;
using System.Collections;

public class ElevatorMalfunctionCard : Card {

	public override void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.Downward:
			Debug.Log ("Moved downward");
			break;
		}
	}
}

