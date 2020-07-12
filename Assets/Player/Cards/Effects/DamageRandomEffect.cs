using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRandomEffect : CardEffect
{

    public float damage = 10;
    public int targets = 1;
    public override void ExecuteEffect(Collider[] colliders) {
        List<Enemy> enemies = EnemyController.Instance.GetEnemies();
        int left = targets;
        while (left-- > 0) {
            int randInt = Random.Range(0, enemies.Count);

            enemies[randInt].GetComponent<Enemy>().takeDamage(damage);
        }
      
    }
}
