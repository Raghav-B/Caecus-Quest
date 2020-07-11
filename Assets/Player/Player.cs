using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private static Player player;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float startHealth;
    [SerializeField]
    private float maxArmor;
    [SerializeField]
    private float startArmor;

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
