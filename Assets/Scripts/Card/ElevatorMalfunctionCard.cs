using UnityEngine;
using System.Collections;

public class ElevatorMalfunctionCard : Card {

    public override void ExecuteEffect(Effect e)
    {
        Debug.Log("Moving downward");
    }
}

