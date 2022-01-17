using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float seconds = 10;
    bool hasPackage;
    bool newSprite;

    float timeRemaining = 10;
    float timeScore;
    
    [SerializeField] Text timer;
    [SerializeField] Text gameOverText;
    [SerializeField] Text timeScoreText;
    [SerializeField] Image gameOverScreen;
     [SerializeField] GameObject Card;
     [SerializeField] GameObject TopBar;
    void Start()
    {
        gameOverText.gameObject.SetActive(false); 
        gameOverScreen.gameObject.SetActive(false); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            timeRemaining = Random.Range(20,30);
        }

         if(other.tag == "Destination"){
            // hasPackage = false;
         }

    }
 
 
    void Update()
    {
        // counts down when took a package
        if(hasPackage && timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            seconds = Mathf.FloorToInt(timeRemaining % 60);
        }

        // stops when press X
        if(Input.GetKeyDown(KeyCode.X) && hasPackage){
            hasPackage = false;

            if(FindObjectOfType<Delivery>().correctApartment == true)
            {
                timeScore += seconds;
                timeScoreText.text = "Score: " + timeScore;
            }
            if(FindObjectOfType<Delivery>().correctApartment == false)
            {
                timeScore -= 10;
                
                if(timeScore<0){
                    timeScore=0;
                }
                timeScoreText.text = "Score: " + timeScore;
            }
            
        }
        
        timer.text = "Time Left: " + seconds;

        if (seconds == 0)
        {
            // Check it later
            // Time up, Game stopped
            Debug.Log("Time Up!");
            gameOverText.gameObject.SetActive(true);
            gameOverScreen.gameObject.SetActive(true); 

            Destroy(Card, 0);
            Destroy(TopBar, 0);
            // Pause
            Time.timeScale = 0.0f;
            
            gameOverText.text = "Time's Up! \n \n " +

                                timeScoreText.text + "\n" +

                                FindObjectOfType<Delivery>().scoreText.text;

        }

        // Press R to restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}
