using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusTwoCard : ScriptableObject
{

    public new string name;
    public string description;

    public Sprite artwork;

    public int turnCost;
    public int moveForward;

    public void Print()
    {
        Debug.Log(name + ": " + description + " The card costs: " + turnCost);
    }

}
