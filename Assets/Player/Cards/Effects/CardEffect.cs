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

    public virtual void CreateSpellEffect(Vector3 target) {
        //Debug.Log(target);
        if (SpellEffectContainer != null) Object.Instantiate(SpellEffectContainer, target, Quaternion.identity);
    }

    public virtual void CreateSpellEffect() {
        CreateSpellEffect(GameController.Instance.Target.GetComponent<Transform>());
    }
}
