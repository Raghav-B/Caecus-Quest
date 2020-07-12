using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private static Player instance;

    public float moveSpeed;

    public static Player Instance { get { return instance; } }
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

        health = maxHealth;
        armor = maxArmor;
    }

    public void damageEnemy(Enemy target, float spellDamage) {
        bool isEnemyAlive = target.takeDamage(spellDamage);
        if (!isEnemyAlive) {
            target.die();
        }
    }

    public override void die() {
    
    }

    // Update is called once per frame
    void Update() {
        if (!moveResolved) {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f) {
                transform.position = targetPos;
                moveResolved = true;
                //Debug.Log("Enemy reports resolved");
            }
        }
    }
}
