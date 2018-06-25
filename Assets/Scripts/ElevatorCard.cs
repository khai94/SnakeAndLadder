using UnityEngine;
using System.Collections;

public enum Effect
{
	upward
}

public class StatusSystem : MonoBehaviour {
	public string name;
	public string description;
	public Effect effect;

	public void ExecuteEffect(int i)
	{
		effect = (Effect) i;

		switch (effect) {
		case Effect.upward:
			Debug.Log ("Moving Upwards");
			break;
		}
	}
}
