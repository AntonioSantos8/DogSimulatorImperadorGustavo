using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -4); 
    [SerializeField] private float sensitivity = 3f; 
    [SerializeField] private float minY = -30f, maxY = 60f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        
    }

    void LateUpdate()
    {
       
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
            
            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minY, maxY); 
            
        } 
        if(Input.GetMouseButtonUp(1))
        {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 

        }

       
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
