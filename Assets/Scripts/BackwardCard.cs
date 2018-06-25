using UnityEngine;
using System.Collections;

public enum Effect
{
	backward
}

public class StatusSystem : MonoBehaviour {
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
		}
	}
}

