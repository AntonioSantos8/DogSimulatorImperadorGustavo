using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerCamera;

    public float walkSpeed = 6f;

    public float gravity = -9.81f;

    public float mouseSensitivity = 2f;
    public float lookXLimit = 45f;
    public float speed;
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;
    public bool isCursorLocked = true;
    public bool canMove;
    bool tabActived;
    void Start()
    {
        LockCursor();
        speed = walkSpeed; 
    }

    void Update()
    {
        if (canMove)
            HandleMovement();

        HandleMouseLook();

        if (!tabActived && Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tabActived = true;
            isCursorLocked = false;
        }
        else if (tabActived && Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            tabActived = false;
            isCursorLocked = true;
        }
    }

    void HandleMovement()
    {
        if (!isCursorLocked) return;

        // Verifica se o player está no chão
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Recebe entrada de movimento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Determina a velocidade de acordo com a tecla de corrida

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        // Aplica gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void HandleMouseLook()
    {
        if (isCursorLocked)
        {
            // Calcula movimento do mouse
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Controla rotação no eixo X (vertical)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);

            // Aplica rotação na câmera e no jogador
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

   

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }
}
