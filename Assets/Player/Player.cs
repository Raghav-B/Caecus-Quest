using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private static Player player;

    public float startHealth = 10;
    public float startArmor = 5;

    private Player() {
        setHealth(startHealth);
        setArmor(startArmor);
    }

    public static Player getInstance() {
        if (player == null) {
            player = new Player();
        }
        return player;
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
