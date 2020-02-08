using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject character;
    public GameObject hand;
    private SlowTime slowTime;
    private PlayerManager playerManager;
    private Rotator rotator;
    private Weapon weapon;
    private Flipper flipper;
    public Animator animator;
    public Timer timer;
    public GameObject mainUIOverlay;
    private bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        slowTime = character.GetComponent<SlowTime>();
        playerManager = character.GetComponent<PlayerManager>();
        rotator = character.GetComponentInChildren<Rotator>();
        weapon = character.GetComponentInChildren<Weapon>();
        flipper = character.GetComponentInChildren<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.dead && !doOnce)
        {
            timer.canCount = false;
            animator.SetFloat("speed", 0f);
            animator.SetTrigger("dead");
            slowTime.enabled = false;
            playerManager.enabled = false;
            rotator.enabled = false;
            weapon.enabled = false;
            flipper.enabled = false;
            hand.SetActive(false);
            mainUIOverlay.SetActive(false);
            deathScreen.SetActive(true);
            //Time.timeScale = 0f;
            doOnce = true;
        }
    }
}

