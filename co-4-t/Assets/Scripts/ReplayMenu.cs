using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }

    public void QuitGame()
    {
        Debug.Log("Qutting Game...");
        Application.Quit();
    }
}
