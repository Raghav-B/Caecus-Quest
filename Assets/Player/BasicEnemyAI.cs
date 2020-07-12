using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEditor.UI;
using UnityEngine;

public class BasicEnemyAI : Enemy {
    public float damage = 1;
    public float moveSpeed;

    private bool isRooted;
    // Start is called before the first frame update
    void Awake() {
        health = maxHealth;
        armor = maxArmor;
        targetPos = transform.position;
    }

    public override void Move() {
        if (rootTurns > 0) {
            rootTurns--;
            return;
        }
        int dir = Random.Range(0, 4);
        
        Vector3 newDir = Vector3.forward;

        switch (dir) {
        case 1:
            newDir = Vector3.forward;
            break;
        case 2:
            newDir = Vector3.right;
            break;
        case 3:
            newDir = -Vector3.forward;
            break;
        case 4:
            newDir = -Vector3.right;
            break;
        }
        int[] constraints = TargettedTileController.Instance.GetGameLimits();
        targetPos = transform.position - newDir;
        targetPos.x = Mathf.Clamp(targetPos.x, constraints[0], constraints[1]);
        targetPos.z = Mathf.Clamp(targetPos.z, constraints[2], constraints[3]);
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

    void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player") {
            
            collision.transform.GetComponent<Player>().takeDamage(damage);   
            die();
        }
    }

}