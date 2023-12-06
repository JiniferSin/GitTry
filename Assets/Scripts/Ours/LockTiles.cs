using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTiles : MonoBehaviour
{

    private LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }


    // Update is called once per frame
    void Update()
    {

    }

    

    private void Opened()
    {
       Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*if (col.gameObject.layer == playerLayer)
        {
            Debug.Log("Colliding with player");
            if (inventory.IsInInventory("LEVERHANDLE"))
            {
                Debug.Log("Lever detected");
                BridgeDown();
            }
        }*/
        if (collider.gameObject.layer == playerLayer)
        {
            Debug.Log("Colliding with player");
            if (PlayerInventory.Instance.IsInInventory("OKEY"))
            {
                Opened();
                PlayerInventory.Instance.RemoveItemFromInventory("OKEY");
               
               
            }
        }
    }
}
