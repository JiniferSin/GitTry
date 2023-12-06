using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsPoints : MonoBehaviour
{
    [SerializeField] private Item itemData;

    public static int _points = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectStar();
        }
    }

    public void CollectStar()
    {
        Debug.Log("CollectingStar");
        Destroy(gameObject);
        StarsPoints._points ++;

        SceneManager.LoadScene("GameOver");
    }
}
