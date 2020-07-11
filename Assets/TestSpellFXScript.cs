using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpellFXScript : MonoBehaviour
{
    public GameObject SpellCube;
    GameObject[] cubes = new GameObject[4];
    // Start is called before the first frame update
    void Awake()
    {
        Quaternion rotation = transform.rotation;
        
        for (int i = 0; i < 4; i++) {
            cubes[i] = Object.Instantiate(SpellCube, transform.position, rotation);
            rotation.eulerAngles = rotation.eulerAngles + new Vector3(0f, 90f, 0f);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 4; i++) {
            Destroy(cubes[i], SpellCube.GetComponent<Animation>().clip.length);
        }
    }
}
