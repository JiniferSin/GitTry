using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject reactionObject;
    public float offset = 0.1f;
    private Transform player;
    private Animator animator;
    public float pushStrength = 10.0f;

    private void Start()
    {
        player = reactionObject.transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

            /*if (player.position.x < transform.position.x + offset && player.position.x > transform.position.x - offset)
            {
                Debug.Log("Reacting");
                React();
            }*/
        
    }

    void React()
    {
        animator.SetTrigger("Agro");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                React();
                PlayerMovement._rigidbody.AddForce(new Vector2(0, pushStrength), ForceMode2D.Impulse);
            }
        }
    }
}