using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour { 
    
    public GameObject CardHandUI;
    public List<GameObject> CardList;

    private static DeckController instance;
    public static DeckController Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    public List<CardEffect> GetCardEffects(int cardID) {
        foreach (GameObject card in CardList) {
            if (card is null) Debug.Log("null id:" + cardID);
            CardDataScript currCard = card.GetComponent<CardDataScript>();
            if (currCard.GetCard().cardID == cardID) {
                return currCard.cardEffects;
            }
        }

        return null;
    }

    public void PopulateHand() {
        for (int i = 0; i < CardHandUI.gameObject.transform.childCount; i++) {
           
            Transform child = CardHandUI.gameObject.transform.GetChild(i);
            CardDisplay cardDisplay = child.GetComponent<CardDisplay>();
            cardDisplay.card = DrawCard();

            cardDisplay.RefreshCardInfo();
        }

        GameController.GameStateMachine.SetTrigger("HandPopulated");
    }

    private Card DrawCard() {
        int cardIndex = Random.Range(0, CardList.Count);
        return CardList[cardIndex].GetComponent<CardDataScript>().GetCard();
    }

    public void ReplaceCard() {
        int cardCount = CardHandUI.gameObject.transform.childCount;
        for (int i = 0; i < cardCount; i++) {
            Transform child = CardHandUI.gameObject.transform.GetChild(i);
            if (child.GetComponent<CardDisplay>().getIsTransparent()) {
                CardDisplay cardDisp = child.GetComponent<CardDisplay>();
                cardDisp.card = DrawCard();
                cardDisp.RefreshCardInfo();
                child.GetComponent<CardMouseBehaviour>().resetSize();
                
                cardDisp.setOpaque();
            }
        }

        
    }

    /*
    // Doesn't fkn work. So don't shift left, just replace missing card with ReplaceCard().
    public void ShiftHandLeft() {
        int first = 0;
        int cardCount = CardHandUI.gameObject.transform.childCount;
        for (int i = 0; i < cardCount; i++) {
            Transform child = CardHandUI.gameObject.transform.GetChild(i);
            if (child.GetComponent<CardDisplay>().getIsTransparent()) {
                first = i;
                break;
            }
        }
        CardDisplay cardDispCurr = CardHandUI.transform.GetChild(first).GetComponent<CardDisplay>();
        CardDisplay cardDispNext = null;
        
        Debug.Log("First card:" + first);
        for (int i = first; i < cardCount -1; i++) {
            cardDispNext = CardHandUI.transform.GetChild(i+1).GetComponent<CardDisplay>();
            //cardDispNext.setTransparent();

            cardDispCurr.card = cardDispNext.getCard(); // This mf doesn't change the Card obj properly.

            cardDispCurr.RefreshCardInfo();
            //cardDispCurr.setOpaque();

        }

        if (cardDispNext != null) cardDispNext.setTransparent();
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
