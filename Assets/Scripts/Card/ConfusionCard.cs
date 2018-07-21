using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionCard : MonoBehaviour
{
    public string title;
    public string description;
    public Effect effect;

private MovePiece move;

public void GetMovement(MovePiece movement)
{
    move = movement;
}

public void ExecuteEffect(int i)
{
    
    effect = (Effect)i;

    switch (effect)
    {

        case Effect.Confuse:
            move.currentPiece.status = Status.Confused;
            move.currentPiece.statusDuration = Random.Range(2, 4);
            break;

        default:
            ExecuteEffect(i);
            break;
    }
}
}

