using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BasicEnemyAI : Enemy
{
    public float startHealth = 1;
    public float startArmor = 0;
    public float damage = 1;
    
    // Start is called before the first frame update
    void Awake()
    {
        setHealth(startHealth);
        setArmor(startArmor);
    }

    public override void die() {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
