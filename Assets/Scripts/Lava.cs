using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public PlayerManager character;
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Player" && !character.isBlinking) 
        {
            character.BlinkHurt();
            character.isBlinking = true;
        }
    }
    private void OnCollisionStay2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Player" && !character.isBlinking)
        {
            character.BlinkHurt();
            character.isBlinking = true;
        }
    }
}
