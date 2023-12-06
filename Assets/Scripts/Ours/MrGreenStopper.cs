using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrGreenStopper : MonoBehaviour
{
    public bool hover = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hover == true)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else 
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }
}
