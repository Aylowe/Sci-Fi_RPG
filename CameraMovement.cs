using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float rotationSpeed = 1; //speed of camera rotation
    float mouseX, mouseY; //float to reference mouse axes

    public Transform player; //players transform
    public GameObject target; //target for camera to look at

    
    // LateUpdate is called after all update functions have been called
    void LateUpdate()
    {
        CamControl();
    }

    //Move camera based on mouse movement
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
