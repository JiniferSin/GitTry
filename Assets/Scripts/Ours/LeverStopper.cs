using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStopper : MonoBehaviour
{
    
    [SerializeField] private Animator lever_Animator;
    [SerializeField] private GameObject mrGreenStopper;

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

    private void BoxDown()
    {
        mrGreenStopper.GetComponent<MrGreenStopper>().hover = false;
    }

    private void LeverSwitch()
    {
        lever_Animator.SetTrigger("Switch");
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
            if (PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))
            {
                LeverSwitch();
                PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
                Debug.Log("Lever detected");
                BoxDown();
            }
        }
    }
}
