using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpellFXScript : MonoBehaviour
{
    public GameObject SpellCube;
    GameObject[] cubes = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = transform.rotation;
        
        for (int i = 0; i < 4; i++) {
            cubes[i] = Object.Instantiate(SpellCube, transform.position, transform.rotation);
            transform.Rotate(Vector3.up, 90f);
        }

        for (int i = 0; i < 4; i++) {
            Destroy(cubes[i], SpellCube.GetComponentInChildren<Animation>().clip.length);
        }

        Destroy(gameObject, SpellCube.GetComponentInChildren<Animation>().clip.length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
