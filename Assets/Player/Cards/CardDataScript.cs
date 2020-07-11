using Assets.Player.Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataScript : MonoBehaviour, ICardData
{

    public Card cardInfo;
    public List<CardEffect> cardEffects = new List<CardEffect>()    ;
    public void ExecuteEffect() {
        Debug.Log("Test card effect execution");
    }

    public Card GetCard() {
        return cardInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
