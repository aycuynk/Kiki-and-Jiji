using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCam : MonoBehaviour
{
[SerializeField] Camera mainCamera = Camera.main;
int leftBorder = -10;
int rightBorder = 10;
int topBorder = 11;
int bottomBorder = -11;
 

void LateUpdate() {
    
Vector2 viewSize = new Vector2 (mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
mainCamera.transform.position = new Vector3 (Mathf.Clamp(mainCamera.transform.position.x, leftBorder + viewSize.x, rightBorder - viewSize.x),
            Mathf.Clamp(mainCamera.transform.position.y, bottomBorder + viewSize.y, topBorder - viewSize.y), -11F);
}

}