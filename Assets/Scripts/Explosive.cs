using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
 
    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            Vector2 a = explosionPos - hit.transform.position;
            if (rb != null)
            {
                rb.AddForce(-a * 10, ForceMode2D.Impulse);
            }
        }
    }
}