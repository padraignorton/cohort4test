using UnityEngine;

public class SC_PickItem : MonoBehaviour
{
    public string itemName = "Some Item"; //Each item must have an unique name
    public Texture itemPreview;

    void Start()
    {
        //Change item tag to Respawn to detect when we look at it
        gameObject.tag = "Respawn";
    }

    public void PickItem()
    {
        Destroy(gameObject);
    }
}