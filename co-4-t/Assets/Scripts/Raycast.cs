using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        SelectKeyBeingPickedUpFromRay();
    }




    private void SelectKeyBeingPickedUpFromRay()
    {
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);

            if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("I picked up a " + whatIHit.collider.gameObject.name);
                    if (whatIHit.collider.tag == "Keycards")
                    {
                        if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.redKey)
                        {
                            player.GetComponent<Inventory>().hasRedKey = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }
                    if (whatIHit.collider.tag == "Doors")
                    {
                        if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doormanager.redDoor)
                        {
                            if (player.GetComponent<Inventory>().hasRedKey == true)
                            {
                                player.GetComponent<Inventory>().hasRedKey = false;
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                            }
                            else
                            {
                                Debug.Log("Find the Red Key!");
                            }
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("I picked up a " + whatIHit.collider.gameObject.name);
                    if (whatIHit.collider.tag == "Keycards")
                    {
                        if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.blueKey)
                        {
                            player.GetComponent<Inventory>().hasBlueKey = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }
                    if (whatIHit.collider.tag == "Doors")
                    {
                        if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doormanager.blueDoor)
                        {
                            if (player.GetComponent<Inventory>().hasBlueKey == true)
                            {
                                player.GetComponent<Inventory>().hasBlueKey = false;
                                Destroy(whatIHit.collider.gameObject);
                            }
                            else
                            {
                                Debug.Log("Find the Blue Key!");
                            }
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("I picked up a " + whatIHit.collider.gameObject.name);
                    if (whatIHit.collider.tag == "Keycards")
                    {
                        if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.greenKey)
                        {
                            player.GetComponent<Inventory>().hasGreenKey = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }
                    if (whatIHit.collider.tag == "Doors")
                    {
                        if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doormanager.greenDoor)
                        {
                            if (player.GetComponent<Inventory>().hasGreenKey == true)
                            {
                                player.GetComponent<Inventory>().hasGreenKey = false;
                                Destroy(whatIHit.collider.gameObject);
                            }
                            else
                            {
                                Debug.Log("Find the Green Key!");
                            }
                        }
                    }
                }
            }
        }
    }

    void OnGUI()
    {
        //Inventory UI
        GUI.Label(new Rect(5, 5, 200, 25), "Find the key and escape!!! 'e' to interact");


    }

}