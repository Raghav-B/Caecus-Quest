using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : CardEffect
{

    public bool healPlayer = true;
    public bool healEnemy = true;
    public float healAmt = 50;

    public override void ExecuteEffect(Collider[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {
            if (healPlayer && colliders[i].tag == "Player") {
                colliders[i].GetComponent<Character>().heal(healAmt);
            }

            else if (healEnemy && colliders[i].tag == "Enemy") {
                colliders[i].GetComponent<Character>().heal(healAmt);
            }
        }
    }

}
