using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject[] destinations;
    //GameObject currentDestination;
    int i = 0;
    [SerializeField] Color32 hasOrder = new Color32(1,1,1,1);
    [SerializeField] Color32 noOrder = new Color32(255,122,0,1);

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();


        i = Random.Range (0, destinations.Length);

        spriteRenderer.color = hasOrder;

    }


    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player" ){
            spriteRenderer.color = noOrder;

            i = Random.Range (0, destinations.Length);
        }
    }
}
