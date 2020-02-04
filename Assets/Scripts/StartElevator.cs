using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartElevator : MonoBehaviour
{
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        leftDoorAnimator.SetTrigger("finishTrigger");
        rightDoorAnimator.SetTrigger("finishTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
