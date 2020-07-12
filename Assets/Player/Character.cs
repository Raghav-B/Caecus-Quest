using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour {
    public float maxHealth = 100;
    public float health;
    public float maxArmor = 50;
    public float armor;

    private int rootTurns = 0;

    public Vector3 targetPos;
    public bool moveResolved = true;

    void Awake() {
        health = maxHealth;
        armor = maxArmor;
    }

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
            die();
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

    /**
     * dir:
     * -1, RANDOM
     *  0, UP
     *  1, LEFT
     *  2, DOWN
     *  3, RIGHT
     *  
     *  magnitude:
     *  -1, RANDOM
     */
    public void doMovement(int dir, int magnitude) {
        List<int> moveDirections = checkAvailMoveDirections(magnitude);

        if (moveDirections.Count == 0) {
            Debug.Log(gameObject.name + " cannot perform movement, no space.");
            return;
        }

        if (dir == -1) {
            int choice = Random.Range(0, moveDirections.Count);
            dir = moveDirections[choice];
        }

        //Debug.Log("Performing movement on " + transform.name);
        switch (dir) {
            case 0:
                targetPos = transform.position + transform.forward * magnitude;
                //transform.Translate(transform.forward * magnitude);
                break;
            case 1:
                targetPos = transform.position + -transform.right * magnitude;
                //transform.Translate(transform.right * magnitude);
                break;
            case 2:
                targetPos = transform.position + -transform.forward * magnitude;
                //transform.Translate(-transform.forward * magnitude);
                break;
            case 3:
                targetPos = transform.position + transform.right * magnitude;
                //transform.Translate(-transform.right * magnitude);
                break;
        }
        moveResolved = false;
    }

    public void doMovement(Vector3 origin, int tilesToMove) {
        Vector3 direction = transform.position - origin;
        if (direction.magnitude < 0.5f) {
            doMovement(-1, tilesToMove);
            return;
        }
        direction.Normalize();
        //Debug.Log(direction);
        float angle = Vector3.Angle(Vector3.forward, direction);
        //Debug.Log(angle);
        int dir = (int)angle / 90;
        switch (dir) {
        case 0:
            break;
        case 1:
            float side = Vector3.Dot(direction, Vector3.right);
            if (side < 0) dir = 1;
            else dir = 3;
            break;
        }
        //Debug.Log(dir);
        doMovement(dir, tilesToMove);
    }

    private List<int> checkAvailMoveDirections(float checkDistance) {
        List<int> moveDirections = new List<int>();
        RaycastHit raycastHit;

        // Check forward
        Physics.Raycast(transform.forward, transform.position, out raycastHit, checkDistance, 
                1, QueryTriggerInteraction.Ignore);
        if (raycastHit.collider == null) {
            moveDirections.Add(0);
            //Debug.Log("No colliders forward");
        }

        // Check right
        Physics.Raycast(transform.right, transform.position, out raycastHit, checkDistance,
                1, QueryTriggerInteraction.Ignore);
        if (raycastHit.collider == null) {
            moveDirections.Add(1);
            //Debug.Log("No colliders right");
        }

        // Check backward
        Physics.Raycast(-transform.forward, transform.position, out raycastHit, checkDistance,
                1, QueryTriggerInteraction.Ignore);
        if (raycastHit.collider == null) {
            moveDirections.Add(2);
            //Debug.Log("No colliders back");
        }

        // Check left
        Physics.Raycast(-transform.right, transform.position, out raycastHit, checkDistance,
                1, QueryTriggerInteraction.Ignore);
        if (raycastHit.collider == null) {
            moveDirections.Add(3);
            //Debug.Log("No colliders left");
        }

        return moveDirections;
    }

    public virtual void die() {
        moveResolved = true;
    }


}
