using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Vector3 worldPosition;
    public Plane plane;
    void Update() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            worldPosition = hit.point;

            Debug.Log(worldPosition);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
