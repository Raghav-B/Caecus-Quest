using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private static Player instance;

    public float moveSpeed;
    public Animator playerAnimator;

    public static Player Instance { get { return instance; } }
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

        health = maxHealth;
        armor = maxArmor;

        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        playerAnimator.SetTrigger("Idling");
    }

    public override void die() {
        playerAnimator.SetTrigger("Dead");
        playerAnimator.ResetTrigger("Idling");
    }

    // Update is called once per frame
    void Update() {
        if (!moveResolved) {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);

            if (targetPos.x > transform.position.x || targetPos.z > transform.position.z) {
                playerAnimator.SetTrigger("MovingRight");
                playerAnimator.ResetTrigger("Idling");
            } else {
                playerAnimator.SetTrigger("MovingLeft");
                playerAnimator.ResetTrigger("Idling");
            }

            if (Vector3.Distance(transform.position, targetPos) < 0.01f) {
                transform.position = targetPos;
                moveResolved = true;
                playerAnimator.SetTrigger("Idling");
                playerAnimator.ResetTrigger("MovingLeft");
                playerAnimator.ResetTrigger("MovingRight");
            }
        }
    }
}
