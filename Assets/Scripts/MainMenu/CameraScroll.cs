using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public GameObject cam;
    private float startpos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startpos = cam.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
        startpos += speed;
    }
}
