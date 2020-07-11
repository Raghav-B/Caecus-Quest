using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    public bool moveResolved = true;

    public void damagePlayer(int damage) {

        bool isPlayerAlive = Player.getInstance().takeDamage(damage);
        if (!isPlayerAlive) {
            Player.getInstance().die();
        }
    }

    public virtual void Move() {

    }
}
