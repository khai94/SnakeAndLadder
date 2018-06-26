using UnityEngine;
using System.Collections;

public class ElevatorCard : Card {

	public override void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.Upward:
			Debug.Log ("Moving Upwards");
			break;
		}
	}
}
