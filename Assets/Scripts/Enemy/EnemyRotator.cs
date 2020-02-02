using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    public GameObject rotated;
    public GameObject player;
    public Transform enemyTrans;
    public CanSeeScript cansee;
    private bool flipped = false;
    private void FixedUpdate()
    {
        if (cansee.inVision)
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //if (rotZ > 270)
            //{
            rotated.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
            //}
            //Almost works, but rotZ nor transform.rotation.z aren't the real rotation
            if (rotZ + 90 > 0 && flipped)
            {
                Vector3 charScale = enemyTrans.localScale;
		        charScale.x *= -1;
		        enemyTrans.localScale = charScale;
                flipped = false;
            }
            else if (rotZ + 90 < 0 && !flipped)
            {
                Vector3 charScale = enemyTrans.localScale;
		        charScale.x *= -1;
		        enemyTrans.localScale = charScale;
                flipped = true;
            }
        }
    }
}
