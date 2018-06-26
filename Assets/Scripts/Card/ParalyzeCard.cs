using UnityEngine;
using System.Collections;

public class ParalyzeCard : Card {
	

	public override void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.Stun:
			Debug.Log ("Stunned");
			break;
		}
	}
}