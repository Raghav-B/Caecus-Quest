using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    
    [SerializeField]
    private float damage;
    
    public Enemy(float startHealth, float startArmor, float damage) {
        setHealth(startHealth);
        setArmor(startArmor);
        this.damage = damage;
    }

    public void damagePlayer() {
        bool isPlayerAlive = Player.getInstance().takeDamage(damage);
        if (!isPlayerAlive) {
            Player.getInstance().die();
        }
    }

    public override void die() {
    }
}
