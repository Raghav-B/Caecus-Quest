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

    }
}
