using UnityEngine;
using System.Collections;

public enum Effect
{
	downward
}

public class StatusSystem : MonoBehaviour {
	public string name;
	public string description;
	public Effect effect;

	public void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.downward:
			Debug.Log ("Moved downward");
			break;
		}
	}
}

