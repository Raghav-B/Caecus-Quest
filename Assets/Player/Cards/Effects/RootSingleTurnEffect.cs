using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSingleTurnEffect : CardEffect
{
	public bool rootPlayer = false;
	public bool rootEnemy = true;
	public bool randomTarget = false;
	public int turns = 1;

	public override void ExecuteEffect(Collider[] colliders) {
		if (randomTarget) {
			List<Enemy> enemies = EnemyController.Instance.GetEnemies();
			int randIndex = Random.Range(0, enemies.Count);
			enemies[randIndex].GetComponent<Enemy>().addRootTurn(turns);
		}

		for (int i = 0; i < colliders.Length; i++) {
			if (rootEnemy && colliders[i].tag == "Enemy") {
				colliders[i].GetComponent<Enemy>().addRootTurn(turns);
			}

			else if (rootPlayer && colliders[i].tag == "Player") {
				colliders[i].GetComponent<Player>().addRootTurn(turns);
			}
		}
	}
}
