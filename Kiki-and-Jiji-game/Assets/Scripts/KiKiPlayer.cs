using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiKiPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    //[SerializeField] float steerSpeed = 15f;

    void Start()
    {
         Time.timeScale = 1f;
    }


    void Update()
    { 
        Move();
        float moveAmountY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveAmountX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmountY, 0);
        transform.Translate(moveAmountX, 0, 0);


        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3( -1.2f, 1.2f, 0);
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3( 1.2f, 1.2f, 0);
        }
        
        

        //transform.Rotate(0, 0, -steerAmount);
    }

float xMin = -7f;
float xMax = 7f;
float yMin = -4f;
float yMax = 4f;
     
public void Move()
{
     Vector3 tmp = transform.position;
     if(tmp.x < xMin){
         tmp.x = xMin;
     }
     else if(tmp.x > xMax){
         tmp.x = xMax;
     }
     else if(tmp.y < yMin){
         tmp.y = yMin;
     }
     else if(tmp.y > yMax){
         tmp.y = yMax;
     }
     transform.position  = tmp;
 }
}
