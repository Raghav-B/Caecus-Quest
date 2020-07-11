using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.AssetImporters;
using UnityEditorInternal;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController gameController;
    public GameObject Target;
    private DeckController deckController;
    private int cardIDExecute;

    // Start is called before the first frame update
    void Awake()
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
            Debug.Log("Radius:" + effect.radius);

            Collider[] colliders = Physics.OverlapSphere(Target.transform.position, effect.radius);
            Debug.Log("colliders:" + colliders.Length);
            effect.ExecuteEffect(colliders);
        }
    }
}
