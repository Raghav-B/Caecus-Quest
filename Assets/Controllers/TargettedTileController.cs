using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TargettedTileController : MonoBehaviour
{
    public int size = 0;
    public GameObject tileIndicator;
    public float delay = 0.5f;

    private float lastCall;

    // Start is called before the first frame update
    void Start()
    {
        lastCall = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changePos(Vector3 targetLocation) {
        if (Time.time > lastCall + delay) {
            targetLocation = new Vector3((int)targetLocation.x, 0, (int)targetLocation.z);
            transform.position = targetLocation;
            lastCall = Time.time;
        }
    }

    void SizeController() {
        if (size == 0) {
            return;
        }
    }
}
