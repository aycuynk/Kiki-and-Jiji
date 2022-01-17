using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMo : MonoBehaviour
{
    [SerializeField] GameObject newCloud;
    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(moveSpeed * Time.deltaTime, 0,0);
        if(newCloud.transform.position.x < -45)
        {
            newCloud.transform.position = new Vector3(Random.Range(30, 40), Random.Range(-35, 35), 0);
            Instantiate(newCloud);
        }
        
    }
}
