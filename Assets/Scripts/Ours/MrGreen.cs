using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrGreen : MonoBehaviour
{
    public GameObject reactionObject;
    public float offsetX = 2;
    public float offsetY = 2;
    private Transform player;
    private Animator animator;
    bool blocked= false;
    // Start is called before the first frame update
    void Start()
    {
        player = reactionObject.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            if (blocked == false)
            {
                Debug.Log("ReactingNotBlocked");
            if (player.position.y < transform.position.y + offsetY && player.position.y > transform.position.y - offsetY)
            {
                if (player.position.x < transform.position.x + offsetX && player.position.x > transform.position.x - offsetX)
                {
                    Debug.Log("ReactingInRange");
                    React();
                }
                else
                {
                    Debug.Log("I'm outta here");
                    animator.SetBool("Smile", false);
                }
            }
            if (blocked == true)
            {
                animator.SetBool("Smile", false);
            }

        }
        
    }

    void React()
    {
        animator.SetBool("Smile", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                blocked = true;
            }
        }
        else
        {
            blocked = false;
        }
    }
}
