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

    private bool isTransparent = false;
    public void RefreshCardInfo()
    {
        cardName.text = card.cardName;
        description.text = card.description;
        if (card.splashArt != null) splashArt.sprite = card.splashArt;
        
    }
    
    public void toggleTransparency() {
        GetComponent<CanvasGroup>().alpha = isTransparent ? 1 : 0;
        isTransparent = !isTransparent;

    }

}
