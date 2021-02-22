using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SCHealth : MonoBehaviour
{
    public GameManager manager;
    public Slider healthBar;
    public float health = 100f;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20f);
        }
        
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            TakeDamage(5f);
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            TakeDamage(0f);
        }
    }

    public void TakeDamage(float amnt)
    {
        health -= amnt;
        if(health <= 0f)
        {
            manager.GameOver();
        }
        float _h = Mathf.Clamp(health, 0, 100f);
        healthBar.value = _h;
    }
}

