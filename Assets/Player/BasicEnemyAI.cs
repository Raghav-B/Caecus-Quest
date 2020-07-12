using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEditor.UI;
using UnityEngine;

public class BasicEnemyAI : Enemy {
    public float damage = 1;
    public float moveSpeed;

    private bool move = false;
    private bool playerHit = true;

    // Start is called before the first frame update
    void Awake() {
        health = maxHealth;
        armor = maxArmor;
        targetPos = transform.position;
    }

    public override void Move() {
        targetPos = transform.position - Vector3.forward;
        moveResolved = false;
        playerHit = false;
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

    void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player") {
            
            collision.transform.GetComponent<Player>().takeDamage(damage);   
            die();
        }
    }

}