using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool finished = false;
    public GameObject levelComplete;
    public GameObject character;
    private SlowTime slowTime;
    private PlayerManager playerManager;
    private Rotator rotator;
    private Flipper flipper;
    private Weapon weapon;
    public Animator playerAnimator;
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;
    public Timer timer;
    public GameObject mainUIOverlay;
    public PauseMenu pauseMenu;
    private bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        slowTime = character.GetComponent<SlowTime>();
        playerManager = character.GetComponent<PlayerManager>();
        rotator = character.GetComponentInChildren<Rotator>();
        weapon = character.GetComponentInChildren<Weapon>();
        flipper = character.GetComponent<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finished && !doOnce)
        {
            timer.canCount = false;
            playerManager.canMove = false;
            playerAnimator.SetFloat("speed", 0f);
            playerAnimator.SetTrigger("finishTrigger");
            leftDoorAnimator.SetTrigger("finishTrigger");
            rightDoorAnimator.SetTrigger("finishTrigger");
            slowTime.enabled = false;
            rotator.enabled = false;
            weapon.enabled = false;
            pauseMenu.enabled = false;
            flipper.enabled = false;
            mainUIOverlay.SetActive(false);
            levelComplete.SetActive(true);
            doOnce = true;
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

