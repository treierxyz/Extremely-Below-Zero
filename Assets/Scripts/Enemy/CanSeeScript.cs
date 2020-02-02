using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeScript : MonoBehaviour
{
    public bool inVision;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            inVision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            inVision = false;
        }
    }
}
