using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Vector3 worldPosition;
    public Plane plane;
    public GameObject TileIndicator;

    private TargettedTileController tileIndicatorScript;
    void Update() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            worldPosition = hit.point;

            //Debug.Log(worldPosition);
        }

        if (Input.GetMouseButtonDown(0)) {
            float deltaX = Mathf.Clamp((Input.GetAxis("Horizontal") * 100), -1, 1);
            float deltaZ = Mathf.Clamp((Input.GetAxis("Vertical") * 100), -1, 1);

            Vector3 targetPos = new Vector3(Mathf.RoundToInt(worldPosition.x), 0f, Mathf.RoundToInt(worldPosition.z));
            Debug.Log("Target:" + targetPos);
            tileIndicatorScript.targetLocation = targetPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tileIndicatorScript = TileIndicator.GetComponent<TargettedTileController>();
    }
}
