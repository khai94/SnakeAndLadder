using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class DoubleDiceCard : ScriptableObject
{

    public new string name;
    public string description;

    public Sprite artwork;

    public int turnCost;
    public int turn;
    public Dice;

	public void Print()
    {
        Debug.Log(name + ": " + description + "The card costs: " + turnCost);
    }
}
