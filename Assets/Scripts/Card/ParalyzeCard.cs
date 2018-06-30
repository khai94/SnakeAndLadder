using UnityEngine;
using System.Collections;

public class ParalyzeCard : Card {

	public override void ExecuteEffect(Effect e)
	{
		Debug.Log ("Stunned");
	}
}