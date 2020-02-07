using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
