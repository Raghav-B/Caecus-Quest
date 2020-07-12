using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFXScript : MonoBehaviour
{

    public GameObject BubbleObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Object.Instantiate(BubbleObject, transform);
        Destroy(obj, obj.GetComponentInChildren<Animation>().clip.length);
        Destroy(gameObject, GetComponentInChildren<Animation>().clip.length);
    }
}
