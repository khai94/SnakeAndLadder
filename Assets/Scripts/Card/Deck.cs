using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();

    private int cardsDealt = 0;
    private bool showReset = false;

    void ResetDeck()
    {
        cardsDealt = 0;
        for(int i = 0; i < hand.Count; i++)
        {
            Destroy(hand[i]);
        }

        hand.Clear();
        cards.Clear();
        cards.AddRange(deck);
        showReset = false;
    }

    /*
    GameObject DealCard()
    {
        if(cards.Count == 0)
        {
            ResetDeck();
        }
    }
    */

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
