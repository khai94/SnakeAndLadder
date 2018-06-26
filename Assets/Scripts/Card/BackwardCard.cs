using UnityEngine;
using System.Collections;

public class BackwardCard : Card {

	public override void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.Backward:
			Debug.Log ("Moved backward");
			break;
		}
	}
}

