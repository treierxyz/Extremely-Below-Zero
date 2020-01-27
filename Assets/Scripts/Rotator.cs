using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject rotated;
    void Start()
    {
        sr = rotated.GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotated.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);

    }
}
