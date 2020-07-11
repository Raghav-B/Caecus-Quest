using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private static Player instance;

    public float startHealth = 10;
    public float startArmor = 5;

    public static Player Instance { get { return instance; } }
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    public void damageEnemy(Enemy target, float spellDamage) {
        bool isEnemyAlive = target.takeDamage(spellDamage);
        if (!isEnemyAlive) {
            target.die();
        }
    }

    public override void die() {
    
    }
}
