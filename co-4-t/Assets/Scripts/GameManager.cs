using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject deathPanel;
    public static bool GameIsPause = false;
    public SC_CharacterController playerController;


    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    public void GameOver()
    {
        //open death panel
        deathPanel.SetActive(true);
        Pause();
        

    }

    public void Retrying()
    {
        Debug.Log("Retrying...");
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Debug.Log("Menu...");
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        GameIsPause = !GameIsPause;

        if (GameIsPause)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }  
    }


}
