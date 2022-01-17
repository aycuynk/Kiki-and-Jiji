using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");   
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
