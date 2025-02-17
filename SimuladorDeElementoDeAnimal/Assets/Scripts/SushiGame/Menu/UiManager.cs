using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] float maxRotX, maxRotY;
    Transform camera;
    [SerializeField] float rotX, rotY;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        
        float mouseX = Input.GetAxis("Mouse X")  * Time.deltaTime * 10;
        float mouseY = Input.GetAxis("Mouse Y")  * Time.deltaTime * 10;

       
        rotY += mouseX;
        rotX -= mouseY;

        
        rotX = Mathf.Clamp(rotX, -maxRotX, maxRotX);

     
        camera.localRotation = Quaternion.Euler(rotX, rotY, 0f);
    }
}
