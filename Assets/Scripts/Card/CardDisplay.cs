using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {
    public Card card;
    public CardDisplayProperties[] properties;

    /*
    public Text nameText;
    public Text descText;
    public Image artworkImage;
    public Text costText;
    public int cost;
    */

	// Use this for initialization
	void OnValidate () {
        LoadCard(card);
        /*
        if (card == null) return;

        nameText.text = card.cardName;
        descText.text = card.description;
        artworkImage.sprite = card.artwork;
        costText.text = card.cost.ToString();
        cost = card.cost;
        */
    }

    public void LoadCard(Card c)
    {
        if (c == null) return;

        for (int i = 0; i < c.properties.Length; i++)
        {
            CardProperties cardProperties = c.properties[i];
            CardDisplayProperties displayProperties = GetProperty(cardProperties.element);

            if (displayProperties == null) continue;

            if(cardProperties.element is ElementText)
            {
                displayProperties.text.text = cardProperties.stringVal;
            }
            else if (cardProperties.element is ElementImage)
            {
                displayProperties.image.sprite = cardProperties.sprite;
            }
            else if (cardProperties.element is ElementInt)
            {
                displayProperties.text.text = cardProperties.intVal.ToString();
            }
        }
        /*
        nameText.text = card.cardName;
        descText.text = card.description;
        artworkImage.sprite = card.artwork;
        costText.text = card.cost.ToString();
        cost = card.cost;
        */
    }

    public CardDisplayProperties GetProperty(Element element)
    {
        CardDisplayProperties result = null;

        for(int i = 0; i < properties.Length; i++)
        {
            if(properties[i].element == element)
            {
                result = properties[i];
                break;
            }
        }
        return result;
    }
}
