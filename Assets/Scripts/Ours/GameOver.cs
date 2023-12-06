using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
   
    public Button play;
    public Button exit;
    
    public void Setup(int points)
    {
        
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        
    }
    void Start()
    {
        play.onClick.AddListener(Play);
        exit.onClick.AddListener(Exit);
    }

    
    void Play()
    {
        SceneManager.LoadScene("World 1-1");
    }

    void Exit()
    {
        Application.Quit();
    }
}
