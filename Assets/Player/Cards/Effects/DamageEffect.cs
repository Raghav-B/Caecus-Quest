using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : CardEffect {

    public float damage;
    public float chanceToHit;

    public override void ExecuteEffect(Collider[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {

            if (colliders[i].tag == "Enemy") {
                if (Random.value <= chanceToHit) {
                    colliders[i].GetComponent<Enemy>().takeDamage(damage);
                } else {
                    // Do nothing
                }
            }
        }
    }
}
