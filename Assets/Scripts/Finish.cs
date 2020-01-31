using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool finished = false;
    public GameObject levelComplete;
    public GameObject character;
    private SlowTime slowTime;
    private PlayerManger playerManger;
    private Rotator rotator;
    private Weapon weapon;
    public Animator playerAnimator;
    public Timer timer;
    public GameObject mainUIOverlay;
    // Start is called before the first frame update
    void Start()
    {
        slowTime = character.GetComponent<SlowTime>();
        playerManger = character.GetComponent<PlayerManger>();
        rotator = character.GetComponentInChildren<Rotator>();
        weapon = character.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(finished);
        if (finished)
        {
            timer.canCount = false;
            playerAnimator.SetFloat("speed", 0f);
            slowTime.enabled = false;
            playerManger.enabled = false;
            rotator.enabled = false;
            weapon.enabled = false;
            mainUIOverlay.SetActive(false);
            levelComplete.SetActive(true);
        }
    }

    public void Finished()
    {
        finished = true;
    }
    
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.tag == "Player") 
        {
            Finished();
        }
    }
}

