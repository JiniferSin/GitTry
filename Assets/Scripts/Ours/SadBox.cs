using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SadBox : MonoBehaviour
{
    public GameObject reactionObject;
    public float offset = 2;
    private Transform player;
    private Animator animator;

    [SerializeField] private int damage = 1;

    void Start()
    {
        player = reactionObject.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            if (player.position.y < transform.position.y)
            {

                if (player.position.x < transform.position.x+offset && player.position.x > transform.position.x-offset)
                {
                    Debug.Log("Reacting");
                    React();
                }
            }
    }

    void React()
    {
       animator.SetTrigger("Fall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                collision.gameObject.GetComponent<PlayerLife>().Hurt(damage);
            }
        }
    }
}