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
            int cardIndex = Random.Range(0, CardList.Count);
            Transform child = CardHandUI.gameObject.transform.GetChild(i);
            CardDisplay cardDisplay = child.GetComponent<CardDisplay>();
            cardDisplay.card = CardList[cardIndex].GetComponent<CardDataScript>().GetCard();

            cardDisplay.RefreshCardInfo();
        }

        GameController.GameStateMachine.SetTrigger("HandPopulated");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
