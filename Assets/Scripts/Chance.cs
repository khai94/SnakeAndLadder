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

	public void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.backward:
			Debug.Log ("Moved backward");
			break;
		
		case Effect.forward:
			Debug.Log ("Moved forward");
			break;
		
		case Effect.stun:
			Debug.Log ("Stunned");
			break;

		case Effect.teleport:
			Debug.Log ("Teleported");
			break;

		case Effect.treasure:
			Debug.Log ("Found treasure");
			break;
		}
	}

}
