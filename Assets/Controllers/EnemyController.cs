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

        UpdateEnemyList();

        //Debug.Log("Found enemy objects:" + enemyList.Count);
    }
    
    public List<Enemy> GetEnemies() {
        return enemyList;
    }

    public bool UpdateEnemyList() {
        enemyList = new List<Enemy>();
        GameObject[] objList = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objList) {
            if (obj.tag == "Enemy" && obj.activeInHierarchy) enemyList.Add(obj.GetComponent<Enemy>());
        }

        if (enemyList.Count == 0) return false;
        return true;
    }

    public void ResolveAIAll() {
        //Debug.Log("Resolving moves");
        foreach (Enemy enemy in enemyList) {
            enemy.Move();
        }
    }

    public bool PollAIResolved() {
        foreach(Enemy enemy in enemyList) {
            if (!enemy.moveResolved) return false;
        }

        return true;
    }
}
