using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffect : CardEffect {

    public int tilesToMove;

    public override void ExecuteEffect(Collider[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].tag == "Player") {

                // -1 for random direction movement.
                colliders[i].GetComponent<Character>().doMovement(-1, tilesToMove);
            }
        }
    }
}
