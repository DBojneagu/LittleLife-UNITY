using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float rotationSpeed = 10f; // Adjust the rotation speed as needed

    void Update()
    {
        // Input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction in local space
        Vector3 localMovement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Convert local movement to world space
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        // Check if there's actual input (prevents diagonal movement from being faster)
        if (worldMovement != Vector3.zero)
        {
            // Calculate the target rotation based on the input
            Quaternion targetRotation = Quaternion.LookRotation(worldMovement, Vector3.up);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the character in world space
            transform.Translate(worldMovement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
