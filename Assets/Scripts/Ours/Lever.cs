using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Lever : MonoBehaviour
{
    [SerializeField] private Animator bridge_Animator;
    [SerializeField] private Animator lever_Animator;

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

    private void BridgeDown()
    {
        bridge_Animator.SetTrigger("Down");
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
                BridgeDown();
            }
        }
    }
    /*public bool IsInInventory(string itemName)
    {
        return items.Find(item => item.uniqueID == itemName) != null;
    }*/
}
