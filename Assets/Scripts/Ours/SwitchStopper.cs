using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStopper : MonoBehaviour
{
    
    [SerializeField] private GameObject mrGreenStopper;
    [SerializeField] private Sprite pressed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void BoxDown()
    {
        mrGreenStopper.GetComponent<MrGreenStopper>().hover = false;
    }

    private void SwitchPress()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
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
        if (collider.gameObject.CompareTag("Box"))
        {

            SwitchPress();
            BoxDown();
            
        }
    }
}
