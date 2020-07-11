using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{

    public int radius = 1;
    public virtual void ExecuteEffect(Collider[] colliders) {
    }
}
