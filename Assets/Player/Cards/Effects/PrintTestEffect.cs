using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTestEffect : CardEffect
{
    public override void ExecuteEffect(Collider[] colliders) {
        Debug.Log("Test effect executed!");
    }
}
