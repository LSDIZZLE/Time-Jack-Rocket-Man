using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 10f;
    public float maxHorizontalRotation = 180f;

    private CharacterController characterController;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // WASD Movement
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalMove, 0, verticalMove);
        movementDirection = transform.TransformDirection(movementDirection);
        movementDirection = movementSpeed * Time.deltaTime;
        characterController.Move(movementDirection);

        // Camera Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Horizontal Rotation
        horizontalRotation += mouseX * rotationSpeed;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -maxHorizontalRotation, maxHorizontalRotation);
        characterController.transform.localRotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        // Vertical Rotation
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }
}