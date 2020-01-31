using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject overlay;
    void ShowUI()
    {
        overlay.SetActive(true);
    }

    void HideUI()
    {
        overlay.SetActive(false);
    }
}
