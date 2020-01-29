using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public GameObject music;
    private AudioSource audioSource;
	public float slowDownAmount;
    public float slowDownDuration;
    public float slowDownRemaining;
    public bool isSlowTime = false;
    private float fixedDeltaTime;
    // Start is called before the first frame update
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        audioSource = music.GetComponent<AudioSource>();
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
                    isSlowTime = true;
                }
                else
                {
                    Time.timeScale = 1.0f;
                    audioSource.pitch = 1.0f;
                    isSlowTime = false;
                }
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
            if (isSlowTime)
            {
                slowDownRemaining -= this.fixedDeltaTime;
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
            isSlowTime = false;
        }
        if (slowDownRemaining <= slowDownDuration && !isSlowTime)
        {
            slowDownRemaining += this.fixedDeltaTime;
        }
	}
}
