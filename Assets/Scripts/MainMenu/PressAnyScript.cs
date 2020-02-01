using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Pressed();
        }
    }
    public void backToPress()
    {
        buttons.SetActive(false);
        title.SetActive(false);
        pressAny.SetActive(true);
        pressed = false;
    }
    public void TriggerTitle()
    {
        animatorT.SetTrigger("transition");
    }
    public void Pressed()
    {
        pressAny.SetActive(false);
        buttons.SetActive(true);
        title.SetActive(true);
    }
}
