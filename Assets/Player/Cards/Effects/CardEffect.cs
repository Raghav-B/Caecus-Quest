using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{

    public float radius = 0.5f;
    public GameObject SpellEffectContainer;
    public virtual void ExecuteEffect(Collider[] colliders) {
    }

    public virtual void CreateSpellEffect(Transform target) {
        if (SpellEffectContainer != null) Object.Instantiate(SpellEffectContainer, target.position, target.rotation);
    }
}
