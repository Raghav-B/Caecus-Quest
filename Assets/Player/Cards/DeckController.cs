using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour { 
    
    public GameObject CardHandUI;
    public List<GameObject> CardList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CardHandUI.gameObject.transform.childCount; i++) {
            int cardIndex = Random.Range(0, CardList.Count);
            Transform child = CardHandUI.gameObject.transform.GetChild(i);
            CardDisplay cardDisplay = child.GetComponent<CardDisplay>();
            cardDisplay.card = CardList[cardIndex].GetComponent<CardDataScript>().GetCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
