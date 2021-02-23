using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Dialogue : MonoBehaviour
{
    public GameObject dialogueManager;
    public static bool GameIsPause = false;
    public SC_CharacterController playerController;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DialogueMenu()
    {
        //open death panel
        dialogueManager.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        dialogueManager.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dialogue"))
        {
            DialogueMenu();
            Destroy(this);
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dialogue"))
        {

        }



    }
}