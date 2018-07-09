using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Data{
    public int playerMoney;
    public List<Card> playerCards;

    // audio settings
    public bool musicIsOn;
    public bool musicToggleIsOn;
}
