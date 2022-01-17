using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class CameraMovements : MonoBehaviour
{
    [SerializeField] Text deliveryInfo;
    [SerializeField] GameObject img;
    [SerializeField] GameObject img1;
     [SerializeField] GameObject Continue;
     [SerializeField] GameObject StartButton;
    bool came;

    void Start() {
        img.SetActive(false);
        img1.SetActive(false);
        Continue.SetActive(false);
    }
    void Update() 
    {
        if(transform.position.x > -13 && transform.position.y < 13){
            transform.position += new Vector3(-5f,5f,0)*Time.deltaTime;

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            transform.position += new Vector3(5f,0,0)*Time.deltaTime;

            
        }
    
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bakery")
        {
            deliveryInfo.text = "Here is the Bakery Shop you are working for."; 
            
            img.SetActive(true);
            img1.SetActive(true);
            Continue.SetActive(true);
        }
        
    }

    public void SecondText (){

        deliveryInfo.text = "You should deliver packages to the right addresses."; 
       

        Continue.SetActive(false);
        StartButton.SetActive(true);

    }

    public void StartToGame (){
        SceneManager.LoadScene("SampleScene");  
    }

}
