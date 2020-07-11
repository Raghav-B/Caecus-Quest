using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private static EnemyController instance;
    private List<Enemy> enemyList;

    public static EnemyController Instance { get { return instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

        enemyList = new List<Enemy>();
        GameObject[] objList = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objList) {
            if (obj.tag == "Enemy") enemyList.Add(obj.GetComponent<Enemy>());
        }
    }

    public void ResolveAIAll() {
        foreach (Enemy enemy in enemyList) {
            enemy.Move();
        }

        GameController.GameStateMachine.SetTrigger("AiResolved");
    }
}
