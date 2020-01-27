using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public GameObject music;
    private AudioSource audioSource;
	public float slowDownAmount;
    public bool isSlowTime = false;
    private float fixedDeltaTime;
    // Start is called before the first frame update
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        audioSource = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
	void Update()
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
    }
}
