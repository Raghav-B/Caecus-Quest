using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : CardEffect {

    public float damage;
    public float chanceToHit;

    public override void ExecuteEffect(Collider[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {
            //Debug.Log("collidr name:" + colliders[i].name);
            if (colliders[i].tag == "Enemy") {
                if (chanceToHit == -1) {
                    chanceToHit = Random.value;
                }

                if (Random.value <= chanceToHit) {
                    Player.Instance.damageEnemy((Enemy)colliders[i].GetComponent<Character>(), damage);
                } else {
                    Debug.Log("Missed");
                    // Do nothing
                }
            }
        }
    }
}
