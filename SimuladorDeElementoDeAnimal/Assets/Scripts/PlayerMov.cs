using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
 private CharacterController controller;
    [SerializeField] private float speed = 5f, rotationSpeed = 10f, gravity = 32;
    [SerializeField] float jumpForce = 14f;
    private Vector3 velocity;
    
    [SerializeField] private Transform cameraTransform; 

    void Start()
    {
        cameraTransform = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }else if( Input.GetButtonDown("Jump") && controller.isGrounded)
        {
    velocity.y = jumpForce;


        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            
         
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

          
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            
        }
     
        
    }
}
