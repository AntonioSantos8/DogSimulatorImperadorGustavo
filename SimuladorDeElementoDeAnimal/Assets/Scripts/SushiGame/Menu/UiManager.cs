using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] float maxRotX, maxRotY;
    [SerializeField] float camVelocity = 10f;
    Transform camera;
    [SerializeField] float rotX, rotY;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        rotX += camera.eulerAngles.x;
        rotY += camera.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

        
        float mouseX = Input.GetAxis("Mouse X")  * Time.deltaTime * camVelocity;
        float mouseY = Input.GetAxis("Mouse Y")  * Time.deltaTime * camVelocity;

       
        rotY += mouseX;
        rotX -= mouseY;

        
        rotX = Mathf.Clamp(rotX, -maxRotX, maxRotX);

     
        camera.localRotation = Quaternion.Euler(rotX, rotY, 0f);
    }
}
