using UnityEngine;
using System.Collections;

public enum Effect
{
	stun
}

public class StatusSystem : MonoBehaviour {
	public string name;
	public string description;
	public Effect effect;

	public void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.stun:
			Debug.Log ("Stunned");
			break;
		}
	}
}