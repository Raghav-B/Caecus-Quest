using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : CardEffect {

    public float damage;
    public float chanceToHit;

    public override void ExecuteEffect(Collider[] colliders) {
        Player.Instance.playerAnimator.SetTrigger("Casting");
        Player.Instance.playerAnimator.ResetTrigger("Idling");

        if (chanceToHit == -1) {
            chanceToHit = Random.value;
        }

        if (Random.value <= chanceToHit) {
            for (int i = 0; i < colliders.Length; i++) {
                //Debug.Log("collidr name:" + colliders[i].name);
                if (colliders[i].tag == "Enemy" || colliders[i].tag == "Player") {
                    Player.Instance.damageCharacter(colliders[i].GetComponent<Character>(), damage);
                }
            }
        } else {
            //Debug.Log("Missed");
            GameController.Instance.showMissAnimation();
        }

        Player.Instance.playerAnimator.SetTrigger("Idling");
    }
}
