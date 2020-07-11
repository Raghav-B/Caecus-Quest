using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TargettedTileController : MonoBehaviour
{
    public int size = 0;
    public GameObject tileIndicator;
    public float delay = 0.5f;
    
        [SerializeField] public int minX = 0;
        [SerializeField] public int maxX = 10;
        [SerializeField] public int minY = 0;
        [SerializeField] public int maxY = 10;


    private float lastCall;
    private static TargettedTileController instance;
    public static TargettedTileController Instance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastCall = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeRandomPos() {
        int newX = Random.Range(minX, maxX + 1);
        int newY = Random.Range(minY, maxY + 1);

        transform.position = new Vector3(newX, 0, newY);
    }

    public void changePos(Vector3 targetLocation) {
        if (Time.time > lastCall + delay) {
            targetLocation = new Vector3((int)targetLocation.x, 0, (int)targetLocation.z);
            transform.position = targetLocation;
            lastCall = Time.time;
        }
    }

    void SizeController() {
        if (size == 0) {
            return;
        }
    }
}
