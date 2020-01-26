using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyScript : MonoBehaviour
{
    public GameObject pressAny;
    public GameObject buttons;
    public GameObject title;
    private bool pressed = false;
    private Animator animatorT;
    // Start is called before the first frame update
    void Start()
    {
        animatorT = title.GetComponent<Animator>();
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && !pressed)
        {
            pressed = true;
            pressAny.SetActive(false);
            buttons.SetActive(true);
            animatorT.SetTrigger("transition");
        }
    }
}
