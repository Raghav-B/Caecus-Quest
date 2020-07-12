using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.AssetImporters;
using UnityEditorInternal;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    private static Animator gameStateMachine;
    
    public GameObject Target;
    public float spellWaitTimer = 2f;
    
    private DeckController deckController;
    private int cardIDExecute;
    private float spellEffectTimer;

    public static GameController Instance { get { return instance; } }
    public static Animator GameStateMachine { get { return gameStateMachine; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        gameStateMachine = GetComponent<Animator>();

        deckController = GetComponent<DeckController>();

        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardIDExecute(int id) {
        cardIDExecute = id;
    }

    public void ApplyEffects() {
        List<CardEffect> effectsList = deckController.GetCardEffects(cardIDExecute);
        foreach(CardEffect effect in effectsList) {
            //Debug.Log("Radius:" + effect.radius);
            Collider[] colliders = Physics.OverlapSphere(Target.transform.position, effect.radius);
            //Debug.Log("colliders:" + colliders.Length);
            effect.ExecuteEffect(colliders);

            effect.CreateSpellEffect();
        }

        spellEffectTimer = Time.time;
    }

    public bool PollSpellEffect() {
        if (Time.time < spellEffectTimer + spellWaitTimer) return false;
        spellEffectTimer = Time.time;
        return true;
    }

    public void RetargetMarker() {
        Target.GetComponent<TargettedTileController>().changeRandomPos();
    }
}
