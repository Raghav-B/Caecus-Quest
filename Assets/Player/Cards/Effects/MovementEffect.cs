using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffect : CardEffect {

    public int tilesToMove;
    public bool PlayerOnly = true;
    public bool PushAway = false;

    public override void ExecuteEffect(Collider[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {

            Character character = colliders[i].GetComponent<Character>();

            if (!PlayerOnly && colliders[i].tag == "Enemy") {
                if (PushAway) character.doMovement(GameController.Instance.Target.transform.position, tilesToMove);
                else character.doMovement(-1, tilesToMove);
            }

            else if (colliders[i].tag == "Player") {

                // -1 for random direction movement.
                if (PushAway) character.doMovement(GameController.Instance.Target.transform.position, tilesToMove);
                else character.doMovement(-1, tilesToMove);
            }
        }
    }
}
