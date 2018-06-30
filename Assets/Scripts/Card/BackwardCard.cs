using UnityEngine;
using System.Collections;

public class BackwardCard : Card {

    public override void ExecuteEffect(Effect e)
    {
        Debug.Log("Moving backward");
    }
}

