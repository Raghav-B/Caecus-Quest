using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootEffect : CardEffect {

    public int rootTurns;
    public float rootChance; 

    public override void ExecuteEffect(Collider[] colliders) {

        if (rootChance == -1) {
            for (int i = 0; i < colliders.Length; i++) {
                if (colliders[i].tag == "Enemy" || colliders[i].tag == "Player") {
                    colliders[i].GetComponent<Character>().setRootTurns(rootTurns);
                }
            }
        } else {
            List<Collider> characterList = new List<Collider>();

            for (int i = 0; i < colliders.Length; i++) {
                if (colliders[i].tag == "Enemy" || colliders[i].tag == "Player") {
                    characterList.Add(colliders[i]);
                }
            }

            int targetChoice = Random.Range(0, characterList.Count);
            colliders[targetChoice].GetComponent<Character>().setRootTurns(rootTurns);
        }

        
    }
}
