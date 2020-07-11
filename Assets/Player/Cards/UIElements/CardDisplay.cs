using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card card;

    public Text cardName;
    public Text description;
    public Image splashArt;
    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        cardName.text = card.cardName;
        description.text = card.description;
        if (card.splashArt != null) splashArt.sprite = card.splashArt;
        
    }
}
