using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TargettedTileController : MonoBehaviour
{
    public Vector3 targetDelta = Vector3.zero;
    public Vector3 targetLocation = Vector3.zero;
    public int size = 0;
    public GameObject tileIndicator;
    public float delay = 1f;

    private float lastCall;

    // Start is called before the first frame update
    void Start()
    {
        lastCall = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastCall + delay && (targetLocation != Vector3.zero || targetDelta != Vector3.zero)) {
            targetLocation = new Vector3((int)targetLocation.x, 0, (int)targetLocation.z);
            transform.position = targetLocation;

            //targetDelta.x = (int)targetDelta.x;
            //targetDelta.z = (int)targetDelta.z;
            //transform.position = targetDelta;
            //targetDelta = Vector3.zero;
            lastCall = Time.time;
        }
    }

    void SizeController() {
        if (size == 0) {
            return;
        }
    }
}
