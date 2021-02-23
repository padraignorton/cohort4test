using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Dialogue : MonoBehaviour
{
    public DTrigger GetDTrigger;
    public GameObject dialogueManager;
    public static bool GameIsPause = false;
    public static bool Dmanager = false;
   
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Dmanager = false;
    }

    private void Update()
    {
        if(Dmanager == true)
        {
            DialogueMenu();
        }
    }

    public void DialogueMenu()
    {
      
      
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPause = true;
        
    }

    public void Close()
    {
        dialogueManager.SetActive(false);
        Destroy(GetDTrigger);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPause = false;
        Dmanager = false;
    }

   
}