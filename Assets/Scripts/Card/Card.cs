using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour {
    public string cardName;
    public string description;
    public Effect effect;

    public abstract void ExecuteEffect(int i);
}
