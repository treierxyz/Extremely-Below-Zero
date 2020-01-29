using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    public GameObject player;
    public Transform arm;
    private bool flipped = false;
    private void FixedUpdate()
    {
        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
        //Almost works, but rotZ nor transform.rotation.z aren't the real rotation
        if (transform.rotation.z < 0 && !flipped)
        {
            Vector3 newScale = new Vector3(-arm.localScale.y,arm.localScale.y,arm.localScale.z);
            arm.localScale = newScale;
            flipped = true;
        }
        else if (transform.rotation.z > 0 && flipped)
        {
            Vector3 newScale = new Vector3(arm.localScale.y,arm.localScale.y,arm.localScale.z);
            arm.localScale = newScale;
            flipped = false;
        }
    }
}
