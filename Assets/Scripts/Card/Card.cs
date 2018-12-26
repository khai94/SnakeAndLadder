using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {
    public CardProperties[] properties;
    /*
    public string cardName;
    public string description;
    public Sprite artwork;
    public int cost;

    
    public Effect effect;
    public TargetMode target;
    */
}
