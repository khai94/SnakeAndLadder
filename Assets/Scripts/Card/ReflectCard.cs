using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReflectCard : MonoBehaviour
{
    public string cardName;
    public string description;
    public Effect effect;

    public abstract void ExecuteEffect(Effect e);
}
