using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevController : MonoBehaviour
{
    public GameObject TileIndicator;
    private TargettedTileController tileIndicatorScript;

    void Awake()
    {
        tileIndicatorScript = TileIndicator.GetComponent<TargettedTileController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            float deltaX = Mathf.Clamp( (Input.GetAxis("Horizontal") * 100), -1, 1);
            float deltaZ = Mathf.Clamp((Input.GetAxis("Vertical") * 100), -1, 1);

            Vector3 targetDelta = new Vector3((int)deltaX, 0f, (int)deltaZ);
            Debug.Log(targetDelta);
            tileIndicatorScript.targetDelta = targetDelta;
        }
    }
}
