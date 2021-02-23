using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTrigger : MonoBehaviour
{
 
    public GameObject dialogueManager;
    public static bool Dmanager = false;

    // Start is called before the first frame update
    void Start()
    {
        Dmanager = false;
    }


    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dmanager = true;
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(dialogueManager);
        }
    }
}
