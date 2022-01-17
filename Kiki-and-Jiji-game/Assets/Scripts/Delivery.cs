using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Delivery : MonoBehaviour
{

    [SerializeField] public AudioSource audioSourcePack;
    [SerializeField] public AudioSource audioSourceSuccess;
    [SerializeField] public AudioSource audioSourceWrong;
    private Animator anim;
    DialogueTrigger dialogueTrigger;
    public bool hasPackage;
    public bool triggerEntered;
    public bool correctApartment;
    [SerializeField] float destroyDelay = 0.3f;

    [SerializeField] GameObject kiki;

    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite newSprite;
    [SerializeField] Sprite oldSprite;
    [SerializeField] GameObject[] newPackages;

    // score
    public int currentScore;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text deliveryInfo;
    [SerializeField] Text apartmentInfo;
    // Destinations
    [SerializeField] GameObject[] destinations;
    int i;

    public void Start() {
        // refrering sprite renderer as a game component
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

        currentScore = 0;

        i = Random.Range (0, destinations.Length);
    }

    public void Update() 
    {
        PackageControl();
        

    }
    
    //OnTriggerEnter (enter or exit can add too)
    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Package" && !hasPackage &&  !audioSourcePack.isPlaying)
        {
            audioSourcePack.Play();
            hasPackage = true;
            anim.SetBool("hasPackage",true);

            DeclaringDestination();

            // gets package on the broom
            spriteRenderer.sprite = newSprite; 
            // destroys package object
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Destination" && hasPackage )
        {
            triggerEntered = true;
            // Show apartment's name
            apartmentInfo.text = other.gameObject.name;

            if(destinations[i].gameObject.name == other.gameObject.name)
            {
                //deliveryInfo.text = "The package delivered to " + other.gameObject.name + " successfully!"; 
               
                correctApartment = true;
            }
            else
            {
                //deliveryInfo.text = "The wrong apartment! "; 
                correctApartment = false;
            }

            //spriteRenderer.sprite = oldSprite; 
            //hasPackage = false;

            // spawing new packages on the random positions
            //newPackage.transform.position = new Vector3(Random.Range(-15, 10), Random.Range(-10, 5), 0);
            

        }

        if(other.tag != "Destination" && hasPackage){
            triggerEntered = false;
        }

        if(other.tag == "Bakery"){
            apartmentInfo.text = other.gameObject.name;
        }
    }


    public void DeclaringDestination()
    {
        i = Random.Range (0, destinations.Length);
        deliveryInfo.text = "Address: \n " + destinations[i].gameObject.name; 
        deliveryInfo.enabled = true;
    }

    public void PackageControl()
    {
        //press X to drop the delivery to that apartment
        if(hasPackage && triggerEntered == true && Input.GetKeyDown(KeyCode.X))
        {
            if(correctApartment)
            {
                // Score++ 
                currentScore++; // Will Change
                scoreText.text = "Delivered Packages: " + currentScore; // (score)

                deliveryInfo.text = "The package delivered to " + destinations[i].gameObject.name + " successfully!";

                audioSourceSuccess.Play();
            }
            else
            {
                deliveryInfo.text = "The wrong apartment! ";
                audioSourceWrong.Play();
            }
            

            spriteRenderer.sprite = oldSprite; 
            hasPackage = false;
            anim.SetBool("hasPackage",false);

            int j = Random.Range (0, newPackages.Length);
            newPackages[j].transform.position = new Vector3(Random.Range(-7,-5), Random.Range(10,12), 0);
            Instantiate(newPackages[j]);
        }

    }

}
