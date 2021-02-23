using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Dialogue : MonoBehaviour
{
    public GameObject dialogueManager;
    public static bool GameIsPause = false;
   
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void DialogueMenu()
    {
      
        dialogueManager.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPause = true;
    }

    public void Close()
    {
        dialogueManager.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPause = false;
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dialogue"))
        {
            DialogueMenu();
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dialogue"))
        {
            Close();
        }



    }
}