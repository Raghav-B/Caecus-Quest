using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DamageRandomEffect : CardEffect
{

    public float damage = 10;
    public int targets = 1;

    private List<Vector3> targetTransforms = new List<Vector3>();

    public override void ExecuteEffect(Collider[] colliders) {
        List<Enemy> enemies = EnemyController.Instance.GetEnemies();
        int left = targets;
        while (left-- > 0) {
            int randInt = Random.Range(0, enemies.Count);

            targetTransforms.Add(enemies[randInt].GetComponent<Transform>().position);

            enemies[randInt].GetComponent<Enemy>().takeDamage(damage);
        }
      
    }

    public override void CreateSpellEffect() {
        for (int i = 0; i < targets; i++) {
            CreateSpellEffect(targetTransforms[i]);
        }
    }
}
