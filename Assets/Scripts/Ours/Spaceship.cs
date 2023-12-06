using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    public Sprite shipSprite;
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
                gameObject.GetComponent<SpriteRenderer>().sprite = shipSprite;
                collider.enabled = false;
                PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
                Debug.Log("Next Level");
                Invoke(nameof(LoadScene), 3f);

                //Make the player beam up 
            }
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
