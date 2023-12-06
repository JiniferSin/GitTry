using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Slimy : MonoBehaviour
{
    public int speed;
    public int direction = 1;
    public GameObject slimeRender;
    public float limitRight;
    public float limitLeft;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * direction * Time.deltaTime, 0, 0);
        if (transform.position.x >= limitRight)
        {
            TurnLeft();
            slimeRender.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (transform.position.x < limitLeft)
        {
            TurnRight();
            slimeRender.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            if (collision.transform.position.y >= transform.position.y)
            {

                if (collision.transform.position.x > transform.position.x)
                {
                    TurnLeft();
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (collision.transform.position.x < transform.position.x)
                {
                    TurnRight();
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }

        }
        
    }*/

    private void TurnRight()
    {
        direction = 1;
    }
    private void TurnLeft()
    {
        direction = -1;
    }
}
