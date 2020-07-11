using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Target;
    private DeckController deckController;
    private int cardIDExecute;

    // Start is called before the first frame update
    void Start()
    {
        deckController = GetComponent<DeckController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyEffects(int cardID) {
        List<CardEffect> effectsList = deckController.GetCardEffects(cardID);
        foreach(CardEffect effect in effectsList) {
            Collider[] colliders = Physics.OverlapSphere(Target.transform.position, effect.radius);
            effect.ExecuteEffect(colliders);
        }
    }
}
