using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject character;
    private SlowTime slowTime;
    private PlayerManger playerManger;
    private Rotator rotator;
    private Weapon weapon;
    private Flipper flipper;
    public Animator animator;
    public Timer timer;
    public GameObject mainUIOverlay;

    // Start is called before the first frame update
    void Start()
    {
        slowTime = character.GetComponent<SlowTime>();
        playerManger = character.GetComponent<PlayerManger>();
        rotator = character.GetComponentInChildren<Rotator>();
        weapon = character.GetComponentInChildren<Weapon>();
        flipper = character.GetComponentInChildren<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManger.dead)
        {
            timer.canCount = false;
            animator.SetFloat("speed", 0f);
            slowTime.enabled = false;
            playerManger.enabled = false;
            rotator.enabled = false;
            weapon.enabled = false;
            flipper.enabled = false;
            mainUIOverlay.SetActive(false);
            deathScreen.SetActive(true);
        }
    }

}

