using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawn : MonoBehaviour
{

    public GameObject SpawnObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Object.Instantiate(SpawnObject, transform);
        Destroy(obj, obj.GetComponentInChildren<Animation>().clip.length);
        Destroy(gameObject, GetComponentInChildren<Animation>().clip.length);
    }
}
