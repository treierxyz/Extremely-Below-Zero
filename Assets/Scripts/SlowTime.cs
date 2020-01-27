using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
	public float slowDownAmount;
    private float fixedDeltaTime;
    // Start is called before the first frame update
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.E))
		{
			if (Time.timeScale == 1.0f)
                Time.timeScale = slowDownAmount;
            else
                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
		}
    }
}
