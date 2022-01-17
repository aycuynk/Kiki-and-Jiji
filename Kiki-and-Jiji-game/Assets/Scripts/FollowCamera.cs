using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;

    Vector3 borderLeft = new Vector3(-50, -40, 0);
    Vector3 borderRight = new Vector3(40, 40, 0);

    void LateUpdate()
    {
        Vector3 playerPos = thingToFollow.transform.position;
        if( borderLeft.x < playerPos.x && playerPos.x < borderRight.x &&
              borderLeft.y < playerPos.y && playerPos.y < borderRight.y)
        {
            transform.position = thingToFollow.transform.position + new Vector3(0,0,-15);
           
        }

         transform.rotation = thingToFollow.transform.rotation;
    }
}
