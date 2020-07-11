using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private float maxHealth;
    private float health;
    private float maxArmor;
    private float armor;

    private int rootTurns = 0;
    
    public float getHealth() {
        return health;
    }

    public void setHealth(float newHealth) {
        health = newHealth;
    }

    public float getArmor() {
        return armor;
    }

    public void setArmor(float newArmor) {
        armor = newArmor;
    }

    public bool takeDamage(float damage) {
        health = health - damage;
        if (health <= 0) {
            return false;
        } else {
            return true;
        }
    }

    public void heal(float healAmount) {
        if (health + healAmount >= maxHealth) {
            health = maxHealth;
        } else {
            health += healAmount;
        }
    }

    public void setRootTurns(int rootTurns) {
        this.rootTurns = rootTurns;
    }

    public int getRootTurns() {
        return rootTurns;
    }

    public virtual void die() {

    }
}
