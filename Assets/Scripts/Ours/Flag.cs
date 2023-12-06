using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    private LayerMask playerLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.layer == playerLayer)
        {
            Debug.Log("Colliding with player");
            if (PlayerInventory.Instance.IsInInventory("REDGEM"))
            {
                PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
                Debug.Log("Next Level");
                SceneManager.LoadScene("World 1-2 1");
                
                //Make the player beam up 
            }
        }
    }
}
