using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEditor.UI;
using UnityEngine;

public class BasicEnemyAI : Enemy {
    public float startHealth = 1;
    public float startArmor = 0;
    public float damage = 1;
    public float moveSpeed;

    private Vector3 targetPos;
    private bool move = false;

    // Start is called before the first frame update
    void Awake() {
        setHealth(startHealth);
        setArmor(startArmor);

        targetPos = transform.position;
    }

    public override void die() {
        gameObject.SetActive(false);
    }

    public override void Move() {
        targetPos = transform.position - Vector3.forward;
        moveResolved = false;
        
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