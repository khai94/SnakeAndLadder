using UnityEngine;
using System.Collections;

public class ElevatorCard : Card {

    public override void ExecuteEffect(Effect e)
    {
        Debug.Log("Moving upward");
    }
}
