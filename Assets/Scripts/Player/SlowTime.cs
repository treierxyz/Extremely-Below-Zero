using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource lazerSource;
    public AudioSource hurtSource;
	public float slowDownAmount;
    public float slowDownDuration;
    public float slowDownRemaining;
    public bool isSlowTime = false;
    public PauseMenu pauseMenu;
    private float fixedUnscaledDeltaTime;
    // Start is called before the first frame update
    void Awake()
    {
        this.fixedUnscaledDeltaTime = Time.fixedUnscaledDeltaTime;
        slowDownRemaining = slowDownDuration;
    }

    // Update is called once per frame
	void Update()
    {
        if (slowDownRemaining > 0)
        {
		    if(Input.GetKeyDown(KeyCode.E))
		    {
		        if (Time.timeScale == 1.0f)
                {
                    Time.timeScale = slowDownAmount;
                    audioSource.pitch = 0.75f;
                    lazerSource.pitch = 0.75f;
                    hurtSource.pitch = 0.75f;
                    isSlowTime = true;
                }
                else
                {
                    Time.timeScale = 1.0f;
                    audioSource.pitch = 1.0f;
                    lazerSource.pitch = 1.0f;
                    hurtSource.pitch = 1.0f;
                    isSlowTime = false;
                }
                Time.fixedDeltaTime = this.fixedUnscaledDeltaTime * Time.timeScale;
            }
            if (isSlowTime && !pauseMenu.gameIsPausedPublic)
            {
                slowDownRemaining -= this.fixedUnscaledDeltaTime;
            }
            if (slowDownRemaining > slowDownDuration)
            {
                slowDownRemaining = slowDownDuration;
            }
        }
        else if (slowDownRemaining < 0)
        {
            Time.timeScale = 1.0f;
            audioSource.pitch = 1.0f;
            lazerSource.pitch = 1.0f;
            hurtSource.pitch = 1.0f;
            isSlowTime = false;
            Time.fixedDeltaTime = this.fixedUnscaledDeltaTime * Time.timeScale;
        }
        if (slowDownRemaining <= slowDownDuration && !isSlowTime && !pauseMenu.gameIsPausedPublic)
        {
            slowDownRemaining += this.fixedUnscaledDeltaTime;
        }
	}
}
